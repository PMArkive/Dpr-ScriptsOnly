using SmartPoint.Components;
using SmartPoint.Rendering;
using UnityEngine;

public class EventCamera
{
    private FieldCamera camera;
    private EventCameraData cameraData;

    public Vector3 defaultPosition { set; get; }
    public Vector3 defaultRotate { set; get; }
    public Vector3 beforePosition { set; get; }
    public Vector3 beforeRotate { set; get; }

    private Vector3 workPosition;
    private Vector3 workRotate;
    private Vector3 retrunDefaultPosition;
    private Vector3 returnDefaultRotate;

    public bool IsEnd { set; get; } = true;

    private DepthOfField _dof;
    private float[] default_dof = new float[3];
    private float[] work_dof = new float[3];
    private Vector3 default_dof_offset = Vector3.zero;
    private Vector3 before_dof_offset = Vector3.zero;
    private Vector3 work_dof_offset = Vector3.zero;
    private EventCameraTable _cameraTbl;
    private float workFov;
    private float beforeFov;
    private float defaultFov;

    public EventCamera(FieldCamera cam)
    {
        camera = cam;
    }

    public void SetCameraData(EventCameraTable tbl, int index)
    {
        SetCameraData(tbl, tbl[index]);
    }

    public void SetCameraData(EventCameraTable tbl, EventCameraData data)
    {
        _cameraTbl = tbl;

        if (_dof == null)
            _dof = DepthOfField.instance;

        default_dof[0] = _dof.farDepth;
        work_dof[0] = _dof.farDepth;
        default_dof[1] = _dof.focalLength;
        work_dof[1] = _dof.focalLength;
        default_dof[2] = _dof.distance;
        work_dof[2] = _dof.distance;

        if (cameraData == null)
            default_dof_offset = _dof.targetOffset;

        before_dof_offset = work_dof_offset;
        work_dof_offset = Vector3.zero;

        beforePosition = workPosition;
        beforeRotate = workRotate;

        workPosition = camera.transform.localPosition;
        workRotate = camera.transform.localEulerAngles;

        defaultFov = camera.Fov;
        beforeFov = workFov;
        workFov = camera.Fov;

        cameraData = data;
        cameraData.baseTime = 0.0f;

        for (int i=0; i<cameraData.isEnd.Count; i++)
            cameraData.isEnd[i] = false;

        for (int i=0; i<cameraData.pathData.Count; i++)
            cameraData.pathData[i].workTime = 0.0f;

        for (int i=0; i<cameraData.dofData.Count; i++)
            cameraData.dofData[i].workTime = 0.0f;

        for (int i=0; i<cameraData.pathData2.Count; i++)
            cameraData.pathData2[i].workTime = 0.0f;

        for (int i=0; i<cameraData.rotationData.Count; i++)
            cameraData.rotationData[i].workTime = 0.0f;

        for (int i=0; i<cameraData.returnDefault.Count; i++)
            cameraData.returnDefault[i].workTime = 0.0f;

        for (int i=0; i<cameraData.returnDefaultRotate.Count; i++)
            cameraData.returnDefaultRotate[i].workTime = 0.0f;

        for (int i=0; i<cameraData.fovData.Count; i++)
            cameraData.fovData[i].workTime = 0.0f;

        IsEnd = false;
    }

    public void Release()
    {
        cameraData = null;
    }

    public void lateUpdate(float deltatime)
    {
        if (cameraData == null)
            return;

        defaultPosition = camera.transform.localPosition;
        defaultRotate = camera.transform.localEulerAngles;
        defaultFov = camera.Fov;

        if (IsEnd)
        {
            camera.transform.localPosition = workPosition;
            camera.transform.localEulerAngles = workRotate;
            camera.Fov = workFov;

            if (_dof == null)
                return;

            _dof.farDepth = work_dof[0];
            _dof.focalLength = work_dof[1];
            _dof.distance = work_dof[2];
        }
        else
        {
            bool ended = false;

            for (int i=0; i<cameraData.length; i++)
            {
                if (cameraData.isEnd[i])
                    continue;

                if (cameraData.startTime[i] > cameraData.baseTime)
                    continue;

                switch (cameraData.type[i])
                {
                    case EventCameraData.EventType.Path:
                        cameraData.isEnd[i] = PathUpdate(cameraData.pathData[i], deltatime);
                        break;

                    case EventCameraData.EventType.Fade:
                        FadeUpdate(cameraData.fadeData[i]);
                        cameraData.isEnd[i] = true;
                        break;

                    case EventCameraData.EventType.EventEnd:
                        cameraData.isEnd[i] = true;
                        if (_dof != null)
                            _dof.targetOffset = default_dof_offset;

                        ended = true;
                        IsEnd = true;
                        break;

                    case EventCameraData.EventType.StopEnd:
                        cameraData.isEnd[i] = true;
                        camera.transform.localPosition = workPosition;
                        camera.transform.localEulerAngles = workRotate;
                        camera.Fov = workFov;
                        IsEnd = true;
                        break;

                    case EventCameraData.EventType.DofLength:
                        if (_dof != null)
                        {
                            for (int j=0; j<cameraData.dofData[i].use.Length; j++)
                            {
                                if (!cameraData.dofData[i].use[j])
                                    continue;

                                float start = cameraData.dofData[i].valStart[j];
                                float end = cameraData.dofData[i].valEnd[j];

                                switch (cameraData.dofData[i].typeStart[j])
                                {
                                    case EventCameraData.DofValType.Defaul:
                                        start = default_dof[j];
                                        break;

                                    case EventCameraData.DofValType.Work:
                                        start = work_dof[j];
                                        break;
                                }

                                switch (cameraData.dofData[i].typeEnd[j])
                                {
                                    case EventCameraData.DofValType.Defaul:
                                        end = default_dof[j];
                                        break;

                                    case EventCameraData.DofValType.Work:
                                        end = work_dof[j];
                                        break;
                                }

                                if (cameraData.dofData[i].workTimeScale == 0.0f)
                                    work_dof[j] = end;
                                else
                                    work_dof[j] = Mathf.Lerp(start, end, cameraData.dofData[i].workTime);

                                switch (j)
                                {
                                    case 0:
                                        _dof.farDepth = work_dof[j];
                                        break;

                                    case 1:
                                        _dof.focalLength = work_dof[j];
                                        break;

                                    case 2:
                                        _dof.distance = work_dof[j];
                                        break;
                                }
                            }

                            var newOffset = cameraData.dofData[i].targetOffset - before_dof_offset;
                            if (cameraData.dofData[i].workTimeScale != 0.0f)
                                newOffset *= cameraData.dofData[i].workTime;

                            work_dof_offset = before_dof_offset + newOffset + default_dof_offset;

                            if (cameraData.dofData[i].workTimeScale > 0.0f)
                            {
                                cameraData.isEnd[i] = cameraData.dofData[i].workTime >= 1.0f;

                                cameraData.dofData[i].workTime += cameraData.dofData[i].workTimeScale * deltatime;
                                if (cameraData.dofData[i].workTime >= 1.0f)
                                    cameraData.dofData[i].workTime = 1.0f;
                            }
                            else
                            {
                                cameraData.isEnd[i] = true;
                            }
                        }
                        else
                        {
                            cameraData.isEnd[i] = true;
                        }
                        break;

                    case EventCameraData.EventType.NewPath:
                        cameraData.isEnd[i] = PathUpdate2(cameraData.pathData2[i], deltatime);
                        break;

                    case EventCameraData.EventType.Rotation:
                        cameraData.isEnd[i] = RotationUpdate(cameraData.rotationData[i], deltatime);
                        break;

                    case EventCameraData.EventType.ReturnDefaultCamera:
                        cameraData.isEnd[i] = ReturnDefault(cameraData.returnDefault[i], deltatime);
                        break;

                    case EventCameraData.EventType.ReturnDefaultRotate:
                        cameraData.isEnd[i] = ReturnDefaultRotate(cameraData.returnDefaultRotate[i], deltatime);
                        break;

                    case EventCameraData.EventType.FieldOfView:
                        cameraData.isEnd[i] = FieldOfViewUpdate(cameraData.fovData[i], deltatime);
                        break;
                }
            }

            cameraData.baseTime += cameraData.timeScale * deltatime;
            camera.transform.localPosition = workPosition;
            camera.transform.localEulerAngles = workRotate;
            camera.Fov = workFov;

            if (_dof == null)
            {
                if (ended)
                    cameraData = null;

                return;
            }

            _dof.farDepth = work_dof[0];
            _dof.focalLength = work_dof[1];
            _dof.distance = work_dof[2];

            if (ended)
            {
                cameraData = null;
                return;
            } 
        }

        _dof.targetOffset = work_dof_offset;
    }

    private bool PathUpdate(EventCameraData.PathData path, float t)
    {
        if (path == null)
            return true;

        Vector3 start;
        Vector3 end;
        switch (path.vTypeStart)
        {
            case EventCameraData.VectorType.Default:
                start = beforePosition;
                break;

            case EventCameraData.VectorType.Before:
                start = defaultPosition;
                break;

            default:
                start = path.startRotation;
                break;
        }

        switch (path.vTypeEnd)
        {
            case EventCameraData.VectorType.Local:
                end = path.endPosition;
                if (path.vTypeStart == EventCameraData.VectorType.Default || path.vTypeStart == EventCameraData.VectorType.Before)
                    end = start + end;
                break;

            case EventCameraData.VectorType.Default:
                end = beforePosition;
                break;

            case EventCameraData.VectorType.Before:
                end = defaultPosition;
                break;

            default:
                end = path.endPosition;
                break;
        }

        Vector3 startRotate = path.startRotation;
        if (path.isDefaultRotate)
            startRotate = defaultRotate;

        if (path.workTimeScale <= 0.0f)
        {
            workPosition = start;
            workRotate = path.endRotation + startRotate;
            return true;
        }
        else
        {
            var posDelta = new Vector3(start.x + path.Vectol.x, start.y + path.Vectol.y, start.z + path.Vectol.z);
            var lerpedPos = Vector3.Lerp(start, posDelta, path.workTime);

            workPosition = Vector3.Lerp(lerpedPos, Vector3.Lerp(lerpedPos, end, path.workTime), path.workTime);
            workRotate = Vector3.Lerp(startRotate, path.endRotation + startRotate, path.workTime);

            var currentTime = path.workTime;
            path.workTime += path.workTimeScale * t;
            return currentTime >= 1.0f;
        }
    }

    private bool PathUpdate2(EventCameraData.PathData2 path, float t)
    {
        if (path == null)
            return true;

        Vector3 start;
        switch (path.vTypeStart)
        {
            case EventCameraData.VectorType.World:
                start = path.Pos1;
                break;

            case EventCameraData.VectorType.Before:
                start = beforePosition;
                break;

            default:
                start = defaultPosition;
                break;
        }

        Vector3 pos3 = start + path.Pos3;
        Vector3 pos2 = start + path.Pos2;

        if (path.workTimeScale <= 0.0f)
        {
            workPosition = pos3;
            return true;
        }
        else
        {
            var curvedT = _cameraTbl.curve.table[path.curveIndex].Evaluate(path.workTime);
            workPosition = Vector3.Lerp(Vector3.Lerp(start, pos2, curvedT), Vector3.Lerp(pos2, pos3, curvedT), curvedT);

            var currentTime = path.workTime;
            path.workTime += path.workTimeScale * t;
            return currentTime >= 1.0f;
        }
    }

    private bool RotationUpdate(EventCameraData.RotationData path, float t)
    {
        if (path == null)
            return true;

        Vector3 startRotate = path.Angle1;
        if (path.isDefaultRotate)
            startRotate = defaultRotate;

        Vector3 finalRot = startRotate + path.Angle2;

        if (path.workTimeScale <= 0.0f)
        {
            workRotate = path.Angle2 + startRotate;
            return true;
        }
        else
        {
            var curvedT = _cameraTbl.curve.table[path.curveIndex].Evaluate(path.workTime);
            workRotate = Vector3.Lerp(startRotate, finalRot, curvedT);

            var currentTime = path.workTime;
            path.workTime += path.workTimeScale * t;
            return currentTime >= 1.0f;
        }
    }

    private bool ReturnDefault(EventCameraData.ReturnDefault path, float t)
    {
        if (path == null)
            return true;

        if (path.workTimeScale <= 0.0f)
        {
            // BUG: Replacing rotation instead of position
            workRotate = defaultPosition;
            return true;
        }
        else
        {
            if (path.workTime <= 0.0f)
                retrunDefaultPosition = workPosition;

            var curvedT = _cameraTbl.curve.table[path.curveIndex].Evaluate(path.workTime);
            workPosition = Vector3.Lerp(retrunDefaultPosition, defaultPosition, curvedT);

            var currentTime = path.workTime;
            path.workTime += path.workTimeScale * t;
            return currentTime >= 1.0f;
        }
    }

    private bool ReturnDefaultRotate(EventCameraData.ReturnDefault path, float t)
    {
        if (path == null)
            return true;

        if (path.workTimeScale <= 0.0f)
        {
            workRotate = defaultRotate;
            return true;
        }
        else
        {
            if (path.workTime <= 0.0f)
                returnDefaultRotate = workRotate;

            var curvedT = _cameraTbl.curve.table[path.curveIndex].Evaluate(path.workTime);
            workRotate = Vector3.Lerp(returnDefaultRotate, defaultRotate, curvedT);

            var currentTime = path.workTime;
            path.workTime += path.workTimeScale * t;
            return currentTime >= 1.0f;
        }
    }

    private bool FieldOfViewUpdate(EventCameraData.FovData path, float t)
    {
        if (path == null)
            return true;

        if (path.workTimeScale <= 0.0f)
        {
            workFov = beforeFov;
            return true;
        }
        else
        {
            if (path.workTime <= 0.0f)
                beforeFov = workFov;

            var curvedT = _cameraTbl.curve.table[path.curveIndex].Evaluate(path.workTime);
            float start = path.is_default_start ? defaultFov : path.field_of_view_start;
            float end = path.is_default_end ? defaultFov : path.field_of_view;

            workFov = Mathf.Lerp(start, end, curvedT);

            var currentTime = path.workTime;
            path.workTime += path.workTimeScale * t;
            return currentTime >= 1.0f;
        }
    }

    private void FadeUpdate(EventCameraData.FadeData fade)
    {
        if (fade == null)
            return;

        Fader.fillColor = fade.color;
        if (fade.type == EventCameraData.FadeType.In)
            Fader.FadeIn(fade.duration);
        else
            Fader.FadeOut(fade.duration);
    }
}