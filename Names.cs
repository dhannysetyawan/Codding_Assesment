using System;
using System.Collections.Generic;
using System.Text;

namespace TestKST
{
    //! class for 
    public class Names
    {
        //! items must be constants
        protected System.Collections.ArrayList m_names = new System.Collections.ArrayList();
        //! private filename unsorted
        string file_unsorted_names_list_txt = "unsorted-names-list.txt";
        //! private filename sorted
        string file_sorted_names_list_txt = "sorted-names-list.txt";
        //! main directory exe
        string current_path;

        //! standard constructor
        public Names() {
            //! init the current path
            current_path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //! if unsorted-names-list.txt  Available will goes well
            if (!Check_available_Unsorted_file()) 
            {
                try {
                    using (System.IO.StreamWriter _writer = System.IO.File.CreateText(System.IO.Path.Combine(current_path, file_unsorted_names_list_txt)))
                    {
                        _writer.Flush();
                        _writer.Close();
                    }
                }
                catch (System.Exception ex)
                {
                    //! at least we know whats the error if fail
                    Console.WriteLine(string.Format("{0} - Names(). Error : {1}", DateTime.Now.ToString(), ex.Message));
                }
            }
        }
        //! deconstructor
        ~ Names(){
        }

        //! append new name into file
        //! any name will appended doesn't check name exists
        public void save_unsorted_into_file(string full_name)
        { 
            try
            {
                //! we use stream writer to append an item
                using (System.IO.StreamWriter _writer = System.IO.File.AppendText(System.IO.Path.Combine(current_path, file_unsorted_names_list_txt)))
                {
                    _writer.WriteLine(string.Format("{0}", full_name));
                    _writer.Flush();
                    _writer.Close();
                }
            }
            catch(System.Exception ex)
            {
                //! at least we know whats the error if fail
                Console.WriteLine(string.Format("{0} - save_unsorted_into_file(). Error : {1}", DateTime.Now.ToString(), ex.Message));
            }

        }

        private bool Check_available_Unsorted_file()
        {
            if(!System.IO.File.Exists(System.IO.Path.Combine(current_path, file_unsorted_names_list_txt)))
                return false;
            return true;
        }

        //! print out sortlist
        public void PrintAsSort()
        {
            load_from_file();
            m_names.Sort(); //! sorting the list
            System.Collections.IEnumerator _list = m_names.GetEnumerator();
            while (_list.MoveNext())
            {
                //! Print into file
                Console.WriteLine(string.Format("{0}", _list.Current));
            }
            save_sorted_file();

        }
       
        //! overwrite a file while update
        private void save_sorted_file()
        {
            try {
                using (System.IO.StreamWriter _writer = System.IO.File.CreateText(System.IO.Path.Combine(current_path, file_sorted_names_list_txt)))
                {
                    m_names.Sort(); //! sorting the list
                    System.Collections.IEnumerator _list = m_names.GetEnumerator();
                    while (_list.MoveNext()) {
                        //! write into file
                        _writer.WriteLine(string.Format("{0}", _list.Current));
                    }
                    _writer.Flush();
                    _writer.Close();
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(string.Format("{0} - save_sorted_file(). Error : {1}", DateTime.Now.ToString(), ex.Message));
            }
        }

        //! load file into array from file unsorted list
        //! private cause we use for print and update sorted list item
        private void load_from_file()
        {
            
            try {
                //! we use stream reader to read a text file
                using (System.IO.StreamReader _read = System.IO.File.OpenText(System.IO.Path.Combine(current_path, file_unsorted_names_list_txt)))
                {
                    while (!_read.EndOfStream)
                    {
                        m_names.Add(string.Format("{0}", _read.ReadLine()));
                    }
                    _read.Close();
                }
            }
            catch (System.Exception ex) 
            {
                Console.WriteLine(string.Format("{0} - load_from_file(). Error : {1}", DateTime.Now.ToString(), ex.Message));
            }

        }


    }
}
