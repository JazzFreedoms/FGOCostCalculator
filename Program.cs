using System;

namespace FGOCostCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfResults = 0;
            int partyCost;

            Console.Write("What is your Total Party Cost? ");
            String input = Console.ReadLine();

            if (!int.TryParse(input, out partyCost))
            {
               Console.Write("Please enter a number between 38 (Master Level 10) and 113 (Master Level 150).");
               return;
            } else if (partyCost < 38) {
                Console.Write("There are no loadouts available with all Servant and Craft Essence slots filled yet. Please play until Master Level 10 then try again.");
                return;
            } else if (partyCost > 113) {
                Console.Write("It is impossible to have higher than 113 Total Party Cost at this moment in time.");
                return;
            }

            Party p = new Party(partyCost);

            foreach (string s in p.TotalCost) {
                Console.WriteLine(parseResult(s));
                numberOfResults++;
            }

            Console.WriteLine("Number of results: " + numberOfResults);
        }

        private static String parseResult(String s) {
            int[] servantCount = new int[6];
            int[] craftEssenceCount = new int[3];

            string[] servantCosts = s.Split("/")[0].Split(":");
            string[] craftEssenceCosts = s.Split("/")[1].Split(":");



            foreach (string sc in servantCosts) {
                if (sc.Equals("16")) {
                    servantCount[0]++;
                } else if (sc.Equals("12")) {
                    servantCount[1]++;
                } else if (sc.Equals("07")) {
                    servantCount[2]++;
                } else if (sc.Equals("04")) {
                    servantCount[3]++;
                } else if (sc.Equals("03")) {
                    servantCount[4]++;
                } else if (sc.Equals("00")) {
                    servantCount[5]++;
                }
            }

            foreach (string cec in craftEssenceCosts) {
                if (cec.Equals("12")) {
                    craftEssenceCount[0]++;
                } else if (cec.Equals("09")) {
                    craftEssenceCount[1]++;
                } else if (cec.Equals("05")) {
                    craftEssenceCount[2]++;
                }
            }

            string servantParsedString = "Servants: " +
                (servantCount[0] > 0 ? servantCount[0] + " Five Star, " : null) + 
                (servantCount[1] > 0 ? servantCount[1] + " Four Star, " : null) + 
                (servantCount[2] > 0 ? servantCount[2] + " Three Star, " : null) + 
                (servantCount[3] > 0 ? servantCount[3] + " Two Star, " : null) + 
                (servantCount[4] > 0 ? servantCount[4] + " One Star, " : null) + 
                (servantCount[5] > 0 ? "Mash, " : null);

            string craftEssenceParsedString = "Craft Essences: " +
                (craftEssenceCount[0] > 0 ? craftEssenceCount[0] + " Five Star, " : null) + 
                (craftEssenceCount[1] > 0 ? craftEssenceCount[1] + " Four Star, " : null) + 
                (craftEssenceCount[2] > 0 ? craftEssenceCount[2] + " Three Star, " : null);

            servantParsedString = servantParsedString.Remove(servantParsedString.Length - 2) + ".";
            craftEssenceParsedString = craftEssenceParsedString.Remove(craftEssenceParsedString.Length - 2) + ".";

            return servantParsedString + " " + craftEssenceParsedString;
        }
    }
}