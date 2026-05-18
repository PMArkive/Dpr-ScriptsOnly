using DG.Tweening;
using Dpr.EvScript;
using Dpr.FureaiHiroba;
using Dpr.Message;
using Dpr.SubContents;
using Dpr.Trainer;
using Pml;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XLSXContent;

namespace Dpr.Field.Walking
{
    public class FieldWalkingManager : WalkingAIManager
    {
        public static bool DebugMode;
        public static TalkState talkState = TalkState.None;
        public AreaID prevArea = AreaID.NOTHING;

        public bool isLoaded { get => prevArea == AreaID.NOTHING; }
        public PokemonParam PartnerPokeParam { get; private set; }

        public string PartnerNPC_ObjectName = "";
        public static Dictionary<int, string> PartnerNPC_Dic = new Dictionary<int, string>()
        {
            { (int)TrainerID.MUSHI_01,   "R201_RIVAL" },
            { (int)TrainerID.MUSHI_02,   "L01_RIVAL" },
            { (int)TrainerID.BTFIVE1_01, "PAIR_D03R0101_SEVEN1" },
            { (int)TrainerID.BTFIVE2_01, "PAIR_D24R0105_SEVEN2" },
            { (int)TrainerID.BTFIVE3_01, "PAIR_D09R0104_SEVEN4" },
            { (int)TrainerID.BTFIVE4_01, "PAIR_D16R0102_SEVEN4" },
            { (int)TrainerID.BTFIVE5_01, "PAIR_D21R0101_SEVEN5" },
        };
        public static Dictionary<string, string> PartnerNameToLabel = new Dictionary<string, string>()
        {
            { "PAIR_D03R0101_SEVEN1", "DLP_SPEAKERS_NAME_024" },
            { "PAIR_D24R0105_SEVEN2", "DLP_SPEAKERS_NAME_068" },
            { "PAIR_D09R0104_SEVEN4", "DLP_SPEAKERS_NAME_059" },
            { "PAIR_D16R0102_SEVEN4", "DLP_SPEAKERS_NAME_063" },
            { "PAIR_D21R0101_SEVEN5", "DLP_SPEAKERS_NAME_030" },
        };

        public Vector3 EntryPoint { get; private set; }

        private Dictionary<int, Object> PokeAssets = new Dictionary<int, Object>();
        private WalkingCharacterController Controller;
        public FieldPokeTalkModel pokeTalkModel;
        private bool isCancel;
        private bool isForceEnter;
        private List<FieldWalkingPokeTalk.SheetSheet1> talkList;
        private FieldWalkingKinomiTable kinomiTable;
        private List<FieldWalkingKinomiSeikakuTable.SheetSheet1> seikakuTable;
        public bool isEvent;
        public bool isBattleRetrurnCreate;
        private Tween deleteTween;
        public Tweener ChangePos;

        public WalkingCharacterController GetPartnerPokeController()
        {
            return PartnerPokeParam != null ? Controller : null;
        }

        public bool IsCanTalk()
        {
            return Controller == null ? false : !Controller.model.isWarping;
        }

        public void NPCToPartner()
        {
            if (Controller != null)
            {
                var model = Controller.model;
                SubWalkingCharacter(model.entity, model.pokePara != null);
                Controller = null;
            }

            if (PartnerNPC_ObjectName == "")
            {
                FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR, false);
                FieldManager.Instance.OnSceneInitEvent -= TurearukiWarp;
            }
            else
            {
                Sequencer.Start(NpcSearch());
            }

            IEnumerator NpcSearch()
            {
                var count = 0.0f;

                do
                {
                    if (PartnerNPC_ObjectName != "")
                    {
                        var fieldObject = EvDataManager.Instanse.GetFieldObject(PartnerNPC_ObjectName);
                        if (fieldObject != null)
                        {
                            Controller = ToWalkingCharacter(fieldObject);
                            Controller.isChousei = false;
                            Controller.model.AI.AddState<NpcWalkingState>();

                            TurearukiWarp();

                            FieldManager.Instance.OnSceneInitEvent -= TurearukiWarp;
                            FieldManager.Instance.OnSceneInitEvent += TurearukiWarp;

                            break;
                        }
                        else
                        {
                            count += Sequencer.elapsedTime;
                            yield return null;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                while (count > 10.0f);
            }
        }

        public IEnumerator LoadMD()
        {
            yield return Utils.LoadAsset("fieldwalking", asset =>
            {
                if (asset.name == "FieldWalkingKinomiSeikakuTable")
                {
                    seikakuTable = ((FieldWalkingKinomiSeikakuTable)asset).Sheet1.ToList();
                }
                else if (asset.name == "FieldWalkingKinomiTable")
                {
                    kinomiTable = (FieldWalkingKinomiTable)asset;
                }
                else if (asset.name == "FieldWalkingPokeTalk")
                {
                    talkList = ((FieldWalkingPokeTalk)asset).Sheet1.ToList();
                }
            });
        }

        public void SetPartnerNpcName(string npcName)
        {
            PartnerNPC_ObjectName = npcName;
        }

        public bool SetPartnerNpcName(TrainerID id)
        {
            if (PartnerNPC_ObjectName == PartnerNPC_Dic[(int)id])
            {
                return false;
            }
            else
            {
                PartnerNPC_ObjectName = PartnerNPC_Dic[(int)id];

                return true;
            }
        }

        public void SetPartnerNameToLabel(int index)
        {
            MessageWordSetHelper.SetGlossaryWord(index, MessageDataConstants.SPEAKER_NAME_FILE_NAME, PartnerNameToLabel[PartnerNPC_ObjectName]);
        }

        public void TurearukiWarp()
        {
            if (Controller != null)
            {
                var entity = Controller.model.entity;

                var onTopOfPlayer = entity.gridPosition == EntityManager.activeFieldPlayer.gridPosition;
                var distance = Vector2Int.Distance(entity.gridPosition, EntityManager.activeFieldPlayer.gridPosition);

                if (distance > 10.0f || onTopOfPlayer)
                {
                    var newPos = AICommon.GetAroundPosition();
                    Controller.model.entity.SetPositionDirect(newPos);
                }
            }
            else
            {
                FieldManager.Instance.OnSceneInitEvent -= TurearukiWarp;
            }
        }

        public void SetPartnerPoke(PokemonParam poke)
        {
            PartnerPokeParam = poke;
            UpdatePartnerPokeIndex();
        }

        public void UpdatePartnerPokeIndex()
        {
            int index;
            if (PartnerPokeParam == null || !IsPokeParaOK(PartnerPokeParam))
                index = 0;
            else
                index = GetTurearukiIndex();

            FlagWork.SetWork(EvWork.WORK_INDEX.WK_PAIR_POKEMON_INDEX, index);
            PlayerWork.TureWalkMemberIndex = index - 1;
            PlayReportManager.SaveReportLog_Tsurearuki();
        }

        public bool IsPokeParaOK(PokemonParam pokepara)
        {
            return !pokepara.IsEgg(EggCheckType.BOTH_EGG) && PartnerPokeParam.GetMonsNo() <= MonsNo.END;
        }

        private int GetTurearukiIndex()
        {
            var memberIndex = PlayerWork.playerParty.GetMemberIndex(PartnerPokeParam);

            if (memberIndex < PokeParty.MAX_MEMBERS)
                return (int)memberIndex + 1;
            else
                return 0;
        }

        public void LoadPartnerPoke()
        {
            var index = FlagWork.GetWork(EvWork.WORK_INDEX.WK_PAIR_POKEMON_INDEX);

            if (index != 0)
            {
                if (index - 1 < PlayerWork.playerParty.GetMemberCount())
                {
                    var member = PlayerWork.playerParty.GetMemberPointer((uint)index - 1);

                    if (IsPokeParaOK(member))
                    {
                        FieldManager.fwMng.PartnerPokeParam = member;
                        return;
                    }
                }

                FieldManager.fwMng.PartnerPokeParam = null;
                PlayerWork.TureWalkMemberIndex = -1;
                FlagWork.SetWork(EvWork.WORK_INDEX.WK_PAIR_POKEMON_INDEX, 0);
            }
            else
            {
                PlayerWork.TureWalkMemberIndex = -1;
            }
        }

        public void SetEntryPoint(Vector3 pos)
        {
            EntryPoint = pos;
        }

        public void CreateTurearuki()
        {
            if (PartnerNPC_ObjectName != "" && PartnerPokeParam != null)
            {
                isForceEnter = true;
                Sequencer.Start(FieldManager.fwMng.CreatePartner());
            }
        }

        public void DeleteTurearuki()
        {
            if (PartnerNPC_ObjectName != "")
                return;

            var cont = GetPartnerPokeController();

            if (cont == null)
                return;

            cont.model?.warpDelay?.Kill();

            if (cont.gameObject.activeInHierarchy)
                cont.model.Exit(false).onComplete = () => cont.gameObject.SetActive(false);
        }

        public IEnumerator CreatePartner(bool isQuiet = false, bool isFormChange = false, bool isAnimeStateReset = false)
        {
            // 0
            isCancel = false;

            if (isEvent)
                yield break;

            var areaID = prevArea;

            yield return null;

            // 1
            var playerPos = EntityManager.activeFieldPlayer.worldPosition;

            if (IsCanTurearuki(PartnerPokeParam))
            {
                if (talkList == null)
                    yield return LoadMD();

                // 2
                if (Controller == null)
                {
                    PokeAssets.Clear();

                    if (!isFormChange)
                        FieldManager.abUnloader.Unload(2);

                    yield return FureaiDataManager.LoadPokeAsset(PartnerPokeParam.GetMonsNo(), PokeAssets, PartnerPokeParam.GetFormNo(), PartnerPokeParam.GetSex(), PartnerPokeParam.IsRare(), 2);
                }

                // 3 & 4
                while (!PlayerWork.isPlayerInputActive && !isQuiet)
                    yield return null;

                if (!IsCanTurearuki(PartnerPokeParam))
                {
                    if (Controller != null)
                    {
                        Controller.model.entity.EventParams.IsInvalidVanishActive = true;
                        Controller.gameObject.SetActive(false);
                    }
                }
                else if (!isCancel)
                {
                    var nearPosList = GetNearEmptyPosition(EntityManager.activeFieldPlayer.gridPosition);
                    if (nearPosList.Count != 0)
                    {
                        var lastPos = nearPosList[nearPosList.Count-1];
                        var newPos = lastPos + EntityManager.activeFieldPlayer.gridPosition;

                        EntryPoint = new Vector3(-newPos.x, playerPos.y + 5.0f, newPos.y);

                        if (Controller != null)
                        {
                            if (areaID != FieldManager.Instance.areaID || isForceEnter)
                            {
                                Controller.model.entity.EventParams.IsInvalidVanishActive = false;
                                Controller.gameObject.SetActive(true);
                                Controller.model.Enter(EntryPoint);

                                EvDataManager.Instanse.FieldObjectEntityAdd(Controller.model.entity);

                                if (pokeTalkModel == null)
                                    pokeTalkModel = new FieldPokeTalkModel(Controller, PartnerPokeParam, talkList, kinomiTable, seikakuTable);

                                pokeTalkModel.isBadStateTalk = true;
                                pokeTalkModel.PrevTalk = null;
                                isForceEnter = false;
                            }

                            if (isAnimeStateReset)
                                Controller.InitState();
                        }
                        else
                        {
                            var catalog = Utils.GetPokemonCatalog(PartnerPokeParam);

                            var go = Object.Instantiate(PokeAssets[catalog.UniqueID]) as GameObject;
                            go.SetActive(true);

                            var patcheel = go.GetComponent<PatcheelPattern>();
                            if (patcheel != null)
                                patcheel.SetPattern(PartnerPokeParam.GetPersonalRnd());

                            go.transform.position = EntryPoint;
                            FureaiHiroba_PokeFactory.SetPokeScale(go.transform, PartnerPokeParam);

                            var fieldEntity = go.GetComponent<FieldPokemonEntity>();

                            Controller = ToWalkingCharacter(fieldEntity);
                            Controller.model.AI.AddState<WalkingState>();
                            Controller.view.isWaitMotionMove = catalog.Waitmoving;
                            Controller.model.SetPokemonParam(PartnerPokeParam);
                            Controller.isFieldWalking = true;
                            Controller.model.moveType = catalog.MoveType;
                            Controller.view.isKwWait = catalog.MoveType != MoveType.FLY;

                            if (catalog.MonsNo == MonsNo.KOIKINGU)
                                Controller.view.isKwWait = false;

                            var scale = Controller.model.entity.transform.localScale;
                            Controller.model.entity.transform.localScale = Vector3.zero;
                            Controller.view.GetAnimPlayer().Play(Controller.view.GetNeutralWaitAnim());

                            pokeTalkModel = new FieldPokeTalkModel(Controller, PartnerPokeParam, talkList, kinomiTable, seikakuTable);

                            Controller.model.walkData.walkSpeed = catalog.WalkSpeed;
                            Controller.model.walkData.runSpeed = catalog.RunSpeed;

                            fieldEntity.EventParams.TalkLabel = "ev_turearuki_poke";
                            fieldEntity.EventParams.TalkRange = catalog.BodySize + 1.5f;
                            fieldEntity.EventParams.TalkBit = 0xF;

                            FieldManager.Instance.OnSceneInitEvent -= TurearukiWarp;
                            FieldManager.Instance.OnSceneInitEvent += TurearukiWarp;

                            EvDataManager.Instanse.FieldObjectEntityAdd(Controller.model.entity);

                            yield return null;

                            // 5
                            Controller.InitAnimationPlayer();

                            Sequencer.earlyLateUpdate += PokeUpdate;

                            if (IsCanTurearuki(PartnerPokeParam))
                            {
                                if (isQuiet)
                                {
                                    Controller.model.entity.transform.localScale = scale;
                                    Controller.model.entity.SetPositionDirect(new Vector3(EntryPoint.x, 30.0f, EntryPoint.z));
                                }
                                else
                                {
                                    Controller.model.Enter();
                                }
                            }
                        }
                    }
                }
            }
            else if (Controller != null && !Controller.isSubWalking)
            {
                Controller.model.entity.EventParams.IsInvalidVanishActive = true;
                Controller.gameObject.SetActive(false);
            }
        }

        public override void Destroy(bool isDestroyGameObject = false)
        {
            isCancel = true;
            base.Destroy(isDestroyGameObject);
            pokeTalkModel = null;

            FieldManager.Instance.OnSceneInitEvent -= TurearukiWarp;
        }

        public void CheckPartnerPokeChange(PokemonParam param, bool isDelete)
        {
            if (param != null && PartnerPokeParam == param)
            {
                FieldManager.fwMng.Destroy(true);

                if (isDelete)
                {
                    var manager = FieldManager.fwMng;
                    manager.PartnerPokeParam = null;
                    manager.UpdatePartnerPokeIndex();
                }
                else if (IsPokeParaOK(param))
                {
                    var manager = FieldManager.fwMng;
                    manager.PartnerPokeParam = param;
                    manager.UpdatePartnerPokeIndex();

                    Sequencer.Start(CreatePartner(true, true, false));
                }
            }
        }

        public bool BtlCheckPartnerPokeChangeFrom(int memberIndex, PokemonParam param)
        {
            if (param == null)
                return false;

            var index = GetTurearukiIndex();

            var currentPartnerIndex = PlayerWork.playerParty.GetMemberIndex(PartnerPokeParam);

            if (index == memberIndex && currentPartnerIndex < PokeParty.MAX_MEMBERS && currentPartnerIndex != uint.MaxValue)
            {
                return PartnerPokeParam.GetMonsNo() == param.GetMonsNo() &&
                       PartnerPokeParam.GetID() == param.GetID() &&
                       PartnerPokeParam.GetPersonalRnd() == param.GetPersonalRnd() &&
                       PartnerPokeParam.GetFormNo() != param.GetFormNo();
            }
            else
            {
                return false;
            }
        }

        public void BtlSetPartnerPokeChangeFrom(PokemonParam param)
        {
            if (param != null)
            {
                FieldManager.fwMng.Destroy(true);
                FieldManager.fwMng.PartnerPokeParam = param;
                FieldManager.fwMng.UpdatePartnerPokeIndex();

                isBattleRetrurnCreate = true;
            }
        }

        public void PokeUpdate(float deltaTime)
        {
            if (pokeTalkModel == null)
            {
                Sequencer.earlyLateUpdate -= PokeUpdate;
            }
            else
            {
                if (Controller == null)
                    return;

                if (Controller.gameObject.activeSelf)
                {
                    pokeTalkModel.WalkUpdate(Controller.model.walkData.entity.moveVector.magnitude);
                    DeleteTurearukiUpdate();
                }
            }
        }

        public void DeleteTurearukiUpdate()
        {
            if (PartnerNPC_ObjectName != "")
                return;

            if (deleteTween == null)
                return;

            var cont = GetPartnerPokeController();

            if (cont == null)
                return;

            if (cont.gameObject.activeInHierarchy && PlayerWork.IsFormSwim())
            {
                if (cont.model != null)
                {
                    cont.model.warpDelay?.Kill();
                    deleteTween = cont.model.Exit(false);
                    deleteTween.onComplete = () =>
                    {
                        cont.gameObject.SetActive(false);
                        deleteTween = null;
                    };
                }
                else
                {
                    deleteTween = null;
                    cont.gameObject.SetActive(false);
                }
            }
        }

        public void ChangePositionNPC()
        {
            if (ChangePos != null)
                return;

            var player = EntityManager.activeFieldPlayer;
            var pos = Controller.model.entity.transform.position;

            if (!Utils.CheckAttributeEnterable(pos))
                return;

            PlayerWork.isPlayerInputActive = false;
            player.isExtrudable = false;

            ChangePos = player.transform.DOMove(pos, 0.15f)
                .SetEase(Ease.InSine)
                .OnUpdate(() => player.GetAnimationPlayer().Play(FieldPlayerEntity.Animation.Walk))
                .OnComplete(() =>
                {
                    PlayerWork.isPlayerInputActive = true;
                    player.isExtrudable = true;
                    player.isExtruded = true;
                    ChangePos = null;
                });

            Controller.model.entity.transform.DOMove(player.transform.position, 0.15f)
                .SetEase(Ease.InSine);
        }

        public bool IsCanTurearuki(PokemonParam param)
        {
            return IsCanTurearukiMap() && IsCanTurearukiState() && param != null && IsPokeParaOK(param) && IsCanTurearukiPoke(param);
        }

        public bool IsCanTurearukiState()
        {
            if (EntityManager.activeFieldPlayer == null)
                return false;

            return !EntityManager.activeFieldPlayer.IsSwim();
        }

        public bool IsCanTurearukiMap()
        {
            return PlayerWork.zoneID != ZoneID.UNKNOWN && GameManager.mapInfo[(int)PlayerWork.zoneID].TureAruki;
        }

        public bool IsCanTurearukiPoke(PokemonParam param)
        {
            return param.GetHp() != 0;
        }

        public void Turearuki_Talk()
        {
            pokeTalkModel?.StartTalk();
        }

        public static void ResetMonohiroiTime()
        {
            FlagWork.SetWork(EvWork.WORK_INDEX.MONOHIROI_TIME, 0);
        }

        public enum TalkState : int
        {
            None = 0,
            Talking = 1,
            TalkEnd = 2,
            DontTalk = 3,
        }
    }
}