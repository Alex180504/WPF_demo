using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсова_Бейчук
{
    static class DBManager
    {
        public static string path_to_db = ".\\Data.csv";

        public static List<AerospaceCompany> GetRecords()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var reader = new StreamReader(path_to_db))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<AerospaceCompany>().ToList();
                return records;
            }
        }

        public static bool CheckKey(string key)   // checks if record with specified name exists in the db
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var reader = new StreamReader(path_to_db))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<AerospaceCompany>().ToList();

                for (int i = 0; i < records.Count(); i++)
                {
                    if (records[i].Name == key)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static List<AerospaceCompany> RemoveKey(List<AerospaceCompany> InputList, string key)  // returns a new list with specified item removed
        {
            bool[] f = new bool[InputList.Count()];
            for (int i = 0; i < f.Length; i++)
            {
                f[i] = false;
            }

            for (int i = 0; i < InputList.Count(); i++)
            {
                if (InputList[i].Name == key)
                {
                    f[i] = true;
                }
            }
            var InputListNew = new List<AerospaceCompany>();
            for (int i = 0; i < InputList.Count(); i++)
            {
                if (f[i] == false)
                {
                    InputListNew.Add(InputList[i]);
                }
            }
            return InputListNew;
        }

        public static void OverwriteList(List<AerospaceCompany> records)    // Overwrites db with input list
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var writer = new StreamWriter(path_to_db))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(records);
            }
        }

        public static void AppendRecord(AerospaceCompany company) // Appends input record to db
        {
            using (var stream = File.Open(path_to_db, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(company);
                csv.NextRecord();
            }
        }
    }
}
