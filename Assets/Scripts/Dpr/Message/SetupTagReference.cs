using System.Collections.Generic;

namespace Dpr.Message
{
    public class SetupTagReference
    {
        public void SetTagReference(List<MessageTagDataModel> tagDataList)
        {
            if (tagDataList == null)
                return;

            if (tagDataList.Count < 1)
                return;

            for (int i=0; i<tagDataList.Count; i++)
            {
                var tagData = tagDataList[i];
                if (IsUseReferenceTag(tagData.patternId))
                {
                    switch (tagData.tagGroupId)
                    {
                        case MessageEnumData.GroupTagID.EN:
                            FormatENTagReference(tagData, tagDataList);
                            break;

                        case MessageEnumData.GroupTagID.FR:
                            FormatFRTagReference(tagData, tagDataList);
                            break;

                        case MessageEnumData.GroupTagID.IT:
                            FormatITTagReference(tagData, tagDataList);
                            break;

                        case MessageEnumData.GroupTagID.DE:
                            FormatDETagReference(tagData, tagDataList);
                            break;

                        case MessageEnumData.GroupTagID.ES:
                            FormatESTagReference(tagData, tagDataList);
                            break;

                        case MessageEnumData.GroupTagID.Kor:
                            FormatKorTagReference(i, tagData, tagDataList);
                            break;

                        case MessageEnumData.GroupTagID.SC:
                            FormatSCTagReference(tagData, tagDataList);
                            break;
                    }
                }
            }
        }

        private bool IsUseReferenceTag(MessageEnumData.TagPatternID targetTagPatternId)
        {
            return targetTagPatternId == MessageEnumData.TagPatternID.Grammar || targetTagPatternId == MessageEnumData.TagPatternID.GrammarWord;
        }

        private void FormatENTagReference(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.ENID)tagData.tagId)
            {
                case MessageEnumData.ENID.Gen:
                    RefGender(tagData, tagDataList);
                    break;

                case MessageEnumData.ENID.Qty:
                    RefQty(tagData, tagDataList);
                    break;

                case MessageEnumData.ENID.GenQty:
                case MessageEnumData.ENID.QtyZero:
                    RefGrmTag(tagData, tagDataList);
                    break;

                default:
                    RefArticle(tagData, tagDataList);
                    break;
            }
        }

        private void FormatFRTagReference(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.FRID)tagData.tagId)
            {
                case MessageEnumData.FRID.Gen:
                    RefGender(tagData, tagDataList);
                    break;

                case MessageEnumData.FRID.Qty:
                    RefQty(tagData, tagDataList);
                    break;

                case MessageEnumData.FRID.GenQty:
                case MessageEnumData.FRID.QtyZero:
                    RefGrmTag(tagData, tagDataList);
                    break;

                default:
                    RefArticle(tagData, tagDataList);
                    break;
            }
        }

        private void FormatITTagReference(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.ITID)tagData.tagId)
            {
                case MessageEnumData.ITID.Gen:
                    RefGender(tagData, tagDataList);
                    break;

                case MessageEnumData.ITID.Qty:
                    RefQty(tagData, tagDataList);
                    break;

                case MessageEnumData.ITID.GenQty:
                case MessageEnumData.ITID.QtyZero:
                    RefGrmTag(tagData, tagDataList);
                    break;

                default:
                    RefArticle(tagData, tagDataList);
                    break;
            }
        }

        private void FormatDETagReference(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.DEID)tagData.tagId)
            {
                case MessageEnumData.DEID.Gen:
                    RefGender(tagData, tagDataList);
                    break;

                case MessageEnumData.DEID.Qty:
                    RefQty(tagData, tagDataList);
                    break;

                case MessageEnumData.DEID.GenQty:
                case MessageEnumData.DEID.QtyZero:
                    RefGrmTag(tagData, tagDataList);
                    break;

                default:
                    RefArticle(tagData, tagDataList);
                    break;
            }
        }

        private void FormatESTagReference(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.ESID)tagData.tagId)
            {
                case MessageEnumData.ESID.Gen:
                    RefGender(tagData, tagDataList);
                    break;

                case MessageEnumData.ESID.Qty:
                    RefQty(tagData, tagDataList);
                    break;

                case MessageEnumData.ESID.GenQty:
                case MessageEnumData.ESID.QtyZero:
                    RefGrmTag(tagData, tagDataList);
                    break;

                default:
                    RefArticle(tagData, tagDataList);
                    break;
            }
        }

        private void FormatKorTagReference(int listIndex, MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.KorID)tagData.tagId)
            {
                case MessageEnumData.KorID.Particle:
                    RefKorParticle(listIndex, tagData, tagDataList);
                    break;

                case MessageEnumData.KorID.Gen:
                    RefGender(tagData, tagDataList);
                    break;

                case MessageEnumData.KorID.Qty:
                    RefQty(tagData, tagDataList);
                    break;

                case MessageEnumData.KorID.GenQty:
                case MessageEnumData.KorID.QtyZero:
                    RefGrmTag(tagData, tagDataList);
                    break;

                default:
                    break;
            }
        }

        private void RefKorParticle(int listIndex, MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            var targetTag = FindTargetTagByListIndex(listIndex - 1, tagDataList);
            if (targetTag != null)
            {
                targetTag.forceArticle = tagData.forceArticle;
                tagData.refTagData = targetTag;
            }
            else
            {
                tagData.refTagData = null;
            }
        }

        private void FormatSCTagReference(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.SCID)tagData.tagId)
            {
                case MessageEnumData.SCID.Gen:
                    RefGender(tagData, tagDataList);
                    break;

                default:
                    MessageHelper.EmitLog("FormatSC : TagId Not Found", UnityEngine.LogType.Error);
                    break;
            }
        }

        private void RefArticle(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            var targetTag = FindTargetTagByIndex(tagData.tagParameter, tagDataList);

            if (targetTag != null)
                targetTag.forceArticle = tagData.forceArticle;

            tagData.refTagData = targetTag;
        }

        private void RefGender(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            if (tagData.tagParameter != MessageDataConstants.REF_TV_GENDER_VALUE && tagData.tagParameter != MessageDataConstants.REF_USER_GENDER_VALUE)
                RefGrmTag(tagData, tagDataList);
        }

        private void RefQty(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            if (tagData.tagParameter != MessageDataConstants.REF_USER_PARTY_VALUE)
                RefGrmTag(tagData, tagDataList);
        }

        private void RefGrmTag(MessageTagDataModel tagData, List<MessageTagDataModel> tagDataList)
        {
            tagData.refTagData = FindTargetTagByIndex(tagData.tagParameter, tagDataList);
        }

        private MessageTagDataModel FindTargetTagByListIndex(int listIndex, List<MessageTagDataModel> tagDataList)
        {
            if (listIndex < 0)
            {
                MessageHelper.EmitLog(string.Format("{0} is under 0", listIndex));
                return null;
            }
                
            if (listIndex >= tagDataList.Count)
            {
                MessageHelper.EmitLog(string.Format("{0} is over List Count {1}", listIndex, tagDataList.Count));
                return null;
            }

            return tagDataList[listIndex];
        }

        private MessageTagDataModel FindTargetTagByIndex(int idx, List<MessageTagDataModel> tagDataList)
        {
            return tagDataList.Find(x => x.index == idx);
        }
    }
}
