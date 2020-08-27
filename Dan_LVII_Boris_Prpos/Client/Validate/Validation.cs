using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Validate
{
    class Validation
    {
        public int ValidateListSelection(List<Item> list,string selectionInput)
        {
            try
            {
                int minimumSelection = 1;
                int maximumSelextion = list.Count();
                int selection;
                bool TryParse = Int32.TryParse(selectionInput, out selection);
                while (!TryParse)
                {
                    Console.WriteLine("Please enter number:");
                    selectionInput = Console.ReadLine();
                    TryParse = Int32.TryParse(selectionInput, out selection);

                    while (selection >= maximumSelextion || selection < minimumSelection)
                    {
                        Console.WriteLine("Please enter number from the list:");

                        int selectionAgain;
                        bool tryAgain = Int32.TryParse(Console.ReadLine(), out selectionAgain);
                        while (!tryAgain)
                        {
                            Console.WriteLine("Please enter number:");
                            tryAgain = Int32.TryParse(Console.ReadLine(), out selectionAgain);
                        }
                        selection = selectionAgain;
                    }
                }

                return selection;
           
            }
            catch (Exception ex)
            {

                //Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        public bool ValidateIntegerInput(string input)
        {
            try
            {
                int result;
                bool tryParse = Int32.TryParse(input, out result);

                if (tryParse==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
