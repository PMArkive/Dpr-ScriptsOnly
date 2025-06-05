using System.Collections.Generic;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
    public class MonohiroiLottery
    {
        public ItemType itemType;
        public bool isSeal;
        private int kinomiNo;
        private int sonotaNo;
        private float kinomiRate = 0.5f;
        private static readonly int[] Sonota_Kakuritu = new int[10]
        {
            15, 15, 15, 15, 10, 10, 8, 5, 5, 2,
        };

        public MonohiroiLottery(FureaiDataManager dataManager, int pokeID)
        {
            var rnd = Random.Range(1, 101);

            var rate = 0;
            foreach (var sheet in dataManager.MonohiroiKinomiList)
            {
                rate += sheet.Kakuritu;
                if (rnd <= rate)
                {
                    kinomiNo = sheet.ItemID;
                    break;
                }
            }

            var pokeItems = dataManager.MonohiroiSonotaList.Find(x => x.PokeID == pokeID);
            var items = new List<int>(10)
            {
                (int)pokeItems.ItemA, (int)pokeItems.ItemB, (int)pokeItems.ItemC,
                (int)pokeItems.ItemD, (int)pokeItems.ItemE, (int)pokeItems.ItemF,
                (int)pokeItems.ItemG, (int)pokeItems.ItemH, (int)pokeItems.ItemI,
                (int)pokeItems.ItemJ,
            };

            var sonotaRate = 0;
            for (int i=0; i<Sonota_Kakuritu.Length; i++)
            {
                sonotaRate += Sonota_Kakuritu[i];

                if (rnd <= sonotaRate)
                {
                    sonotaNo = items[i];
                    isSeal = i != 3 && i != 9; // Only ItemD and ItemJ are proper items, the rest are seals
                    break;
                }
            }
        }

        public int GetItem()
        {
            bool isKinomi = GetItemIsKinomi();
            bool canGetKinomi = ItemWork.IsAddItem(sonotaNo, 1);
            bool canGetSonota = CanGetSonota();

            if (isKinomi)
            {
                if (canGetKinomi)
                    return GetKinomi();
                else if (canGetSonota)
                    return GetSonota();
                else
                    return -1;
            }
            else
            {
                if (canGetSonota)
                    return GetSonota();
                else if (canGetKinomi)
                    return GetKinomi();
                else
                    return -1;
            }
        }

        private int GetKinomi()
        {
            itemType = ItemType.Item;
            return kinomiNo;
        }

        private int GetSonota()
        {
            return sonotaNo;
        }

        private bool CanGetSonota()
        {
            itemType = isSeal ? ItemType.Seal : ItemType.Item;

            if (isSeal)
                return PlayerWork.GetSealData(sonotaNo).Count < 99;
            else
                return ItemWork.IsAddItem(sonotaNo, 1);
        }
        
        private bool GetItemIsKinomi()
        {
            return Random.Range(0.0f, 1.0f) < kinomiRate;
        }

        public enum ItemType : int
        {
            Item = 0,
            Seal = 1,
        }
    }
}