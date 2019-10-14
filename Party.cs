using System;
using System.Collections.Generic;
using System.Linq;

namespace FGOCostCalculator
{
    class Party
    {
        private static int[] ServantCosts = new int[] { 3, 4, 7, 12, 16 };
        private static int[] CraftEssenceCosts = new int[] { 5, 9, 12 };
        private static int PartyCost;
        private static HashSet<String> TotalServantCost;
        public HashSet<String> TotalCost { get; private set; }

        public Party(int partyCost) {
            PartyCost = partyCost;
            TotalServantCost = getTotalServantCost(); 
            TotalCost = getTotalCost();
        }

        private static HashSet<String> getTotalServantCost() {
            HashSet<String> totalServantCost = new HashSet<String>();
            int servantCostSum;
            
            for (int a = 0; a < ServantCosts.Length; a++) {
                for (int b = 0; b < ServantCosts.Length; b++) {
                    for (int c = 0; c < ServantCosts.Length; c++) {
                        for (int d = 0; d < ServantCosts.Length; d++) {
                            for (int e = 0; e < ServantCosts.Length; e++) {
                                servantCostSum = ServantCosts[a] + ServantCosts[b] + ServantCosts[c] + ServantCosts[d] + ServantCosts[e];
                                if (servantCostSum < PartyCost) {
                                    int[] partyServantCost = new int[] {ServantCosts[a], ServantCosts[b], ServantCosts[c], ServantCosts[d], ServantCosts[e]};
                                    Array.Sort(partyServantCost);
                                    Array.Reverse(partyServantCost);
                                    string s = servantCostSum + "|" +
                                        partyServantCost[0].ToString().PadLeft(2, '0') + ":" + 
                                        partyServantCost[1].ToString().PadLeft(2, '0') + ":" + 
                                        partyServantCost[2].ToString().PadLeft(2, '0') + ":" + 
                                        partyServantCost[3].ToString().PadLeft(2, '0') + ":" + 
                                        partyServantCost[4].ToString().PadLeft(2, '0');
                                    totalServantCost.Add(s);
                                }
                            }

                            // calculations for when Mash is in the party
                            servantCostSum = ServantCosts[a] + ServantCosts[b] + ServantCosts[c] + ServantCosts[d] + 0;
                            if (servantCostSum < PartyCost) {
                                int[] partyServantCost = new int[] {ServantCosts[a], ServantCosts[b], ServantCosts[c], ServantCosts[d], 0};
                                Array.Sort(partyServantCost);
                                Array.Reverse(partyServantCost);
                                string s = servantCostSum + "|" + 
                                    partyServantCost[0].ToString().PadLeft(2, '0') + ":" +
                                    partyServantCost[1].ToString().PadLeft(2, '0') + ":" + 
                                    partyServantCost[2].ToString().PadLeft(2, '0') + ":" +
                                    partyServantCost[3].ToString().PadLeft(2, '0') + ":" + 
                                    partyServantCost[4].ToString().PadLeft(2, '0');
                                totalServantCost.Add(s);
                            }
                        }
                    }
                }
            }
            return totalServantCost;
        }

        private HashSet<String> getTotalCost() {
            HashSet<String> totalCost = new HashSet<String>();
            int servantCostSum;
            
            foreach (string totalServantCost in TotalServantCost) {
                servantCostSum = int.Parse(totalServantCost.Split("|")[0]);

                for (int a = 0; a < CraftEssenceCosts.Length; a++) {
                    for (int b = 0; b < CraftEssenceCosts.Length; b++) {
                        for (int c = 0; c < CraftEssenceCosts.Length; c++) {
                            for (int d = 0; d < CraftEssenceCosts.Length; d++) {
                                for (int e = 0; e < CraftEssenceCosts.Length; e++) {
                                    int craftEssenceCostSum = CraftEssenceCosts[a] + CraftEssenceCosts[b] + CraftEssenceCosts[c] + CraftEssenceCosts[d] + CraftEssenceCosts[e];
                                    if (craftEssenceCostSum + servantCostSum == PartyCost) {
                                        int[] partyCraftEssenceCost = new int[] {CraftEssenceCosts[a], CraftEssenceCosts[b], CraftEssenceCosts[c], CraftEssenceCosts[d], CraftEssenceCosts[e]};
                                        Array.Sort(partyCraftEssenceCost);
                                        Array.Reverse(partyCraftEssenceCost);
                                        string s = totalServantCost.Split("|")[1] + "/" + 
                                            partyCraftEssenceCost[0].ToString().PadLeft(2, '0') + ":" + 
                                            partyCraftEssenceCost[1].ToString().PadLeft(2, '0') + ":" + 
                                            partyCraftEssenceCost[2].ToString().PadLeft(2, '0') + ":" + 
                                            partyCraftEssenceCost[3].ToString().PadLeft(2, '0') + ":" + 
                                            partyCraftEssenceCost[4].ToString().PadLeft(2, '0');
                                        totalCost.Add(s);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return totalCost.OrderByDescending(s => s).ToHashSet();
        }
    }
}