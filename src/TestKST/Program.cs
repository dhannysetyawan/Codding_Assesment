using System;
using System.Collections.Generic;
using System.Text;

namespace TestKST
{
    class Program
    {

        static void Main(string[] args)
        {
            //! simple argument 
            if (args.Length == 0)
            {
                //! print usage
                Console.WriteLine(string.Format("P or p         -printout sortedlist. noted when file available"));
                Console.WriteLine(string.Format("N or n         -insert new name"));
                return;
            }
            Names names = new Names();

            if (args[0].ToUpper() == "P")
            {
                names.PrintAsSort();
            }
            if (args[0].ToUpper() == "N")
            {
                int lenght = args.Length; 
                string candidate_name = string.Empty;
                for (int i = 1; i < lenght; i++) {
                    candidate_name += args[i];
                    candidate_name += " "; // space character
                }
                names.save_unsorted_into_file(candidate_name);
            }

        }
    }
}
