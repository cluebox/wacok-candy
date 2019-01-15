using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpssLib.SpssDataset;
using SpssLib.DataReader;
using System.IO;

namespace Wacok_Candy_Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            int SurveyID = 600597;
            //string SurveyPeriod = "2014-09-30";//survey period
            string AttendedOn = "2018-12-31";
            //string year = getYear(SurveyPeriod); 
            string country = "Indonesia";//survey country
            DB_insertion_candy_wacok iobj = new DB_insertion_candy_wacok();
            string questions = "id,weight,S9,S8,S2,S7,S10,S11,S12,CA6,CA1,CA2_1,CA2_2,CA2_3,CA2_4,CA2_5,CA2_6,CA2_7,CA2_8,CA2_9,CA2_10,CA2_11,CA2_12,CA2_13,CA2_14,CA2_15,CA2_16,CA2_17,CA2_18,CA2_19,CA2_20,CA2_21,CA4,CA8_1,CA8_2,CA8_3,CA8_4,CA8_5,CA8_6,CA8_7,CA8_8,CA8_9,CA8_10,CA8_11,CA8_12,CA8_13,CA8_14,CA8_15,CA8_16,CA8_17,CA8_18,CA8_19,CA8_20,CA8_21,CA13,CA3,CA10_1,CA10_2,CA10_3,CA10_4,CA10_5,CA10_6,CA10_7,CA10_8,CA10_9,CA10_10,CA10_11,CA10_12,CA10_13,CA10_14,CA10_15,CA10_16,CA10_17,CA10_18,CA10_19,CA10_20,CA10_21,CA9_1,CA9_2,CA9_3,CA9_4,CA9_5,CA9_6,CA9_7,CA9_8,CA9_9,CA9_10,CA9_11,CA9_12,CA9_13,CA9_14,CA9_15,CA9_16,CA9_17,CA9_18,CA9_19,CA9_20,CA9_21,CA11_1,CA11_2,CA11_3,CA11_4,CA11_5,CA11_6,CA11_7,CA11_8,CA11_9,CA11_10,CA11_11,CA11_12,CA11_13,CA11_14,CA11_15,CA11_16,CA11_17,CA11_18,CA11_19,CA11_20,CA11_21,CA12_1,CA12_2,CA12_3,CA12_4,CA12_5,CA12_6,CA12_7,CA12_8,CA12_9,CA12_10,CA12_11,CA12_12,CA12_13,CA12_14,CA12_15,CA12_16,CA12_17,CA12_18,CA12_19,CA12_20,CA12_21,CA1_Net1,CA1_Net2,CA2_Net1,CA2_Net2,CA4_Net1,CA4_Net2,CA8_Net1,CA8_Net2,CA13_Net1,CA13_Net2,CA3_Net1,CA3_Net2,CA9_Net1,CA9_Net2,CA10_Net1,CA10_Net2,CA11_Net1,CA11_Net2,CA12_Net1,CA12_Net2,CA15,CA16,CA17,CA18,CA19,CA20,CA21,CA22,CA23,CA24,CA25,CA26,CA27,CA28,CA29,CA30,CA31,CA32,CA33,CA34,CA35,C36,CA37,CA38,CA41,CA42,CA43,CA44,S13_1,S13_2,S13_3,S13_4,S13_5,S13_6,S13_7,S13_8,S14_1,S14_2,S14_3,S14_4,S14_5,S14_6,S14_7,S14_8,T2B1_1,T2B1_2,T2B1_3,T2B1_4,T2B1_5,T2B1_6,T2B1_7,T2B1_8,T2B1_9,T2B1_10,CAJU37,CAJU38";// dashboard variable value   
            //string questions = "CAJU37,CAJU38";
            string[] spss_variable_name = questions.Split(',');
            SpssReader spssDataset;
            using (FileStream fileStream = new FileStream(@"D:\spssparsing\wacok\WacockCandyset2_Nov2018.sav", FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan))
            {
                spssDataset = new SpssReader(fileStream); // Create the reader, this will read the file header
                foreach (string spss_v in spss_variable_name)
                {
                    foreach (var variable in spssDataset.Variables)  // Iterate through all the varaibles
                    {
                        if (variable.Name.Equals(spss_v))
                        {
                            foreach (KeyValuePair<double, string> label in variable.ValueLabels)
                            {
                                string VARIABLE_NAME = spss_v;
                                string VARIABLE_NAME_SUB_NAME = variable.Name;
                                string VARIABLE_ID = label.Key.ToString();
                                string VARIABLE_VALUE = label.Value;
                                string VARIABLE_NAME_QUESTION = variable.Label;
                                string BASE_VARIABLE_NAME = variable.Name;
                                //iobj.insert_Dashboard_variable_values(VARIABLE_NAME, VARIABLE_NAME_SUB_NAME, VARIABLE_ID, VARIABLE_VALUE, VARIABLE_NAME_QUESTION, SurveyID, country, BASE_VARIABLE_NAME, AttendedOn);
                            }
                        }

                    }
                }
                foreach (var record in spssDataset.Records)
                {
                    string userID = null;
                    string u_id = null;
                    string variable_name;
                    decimal Weight = 0;
                    string Country = "-- Not Available --";
                    string Education = "-- Not Available --";
                    string Location = "-- Not Available --";
                    string Gender = "-- Not Available --";
                    string MaritalStatus = "-- Not Available --";
                    string AgeGroup = "-- Not Available --";
                    string SES = "-- Not Available --";
                    string Occupation = "-- Not Available --";
                    string CA6 = "-- Not Available --";
                    string BrTom = "-- Not Available --";
                    string BrSpont_Alpenliebe = "-- Not Available --";
                    string BrSpont_Blaster = "-- Not Available --";
                    string BrSpont_Espresso = "-- Not Available --";
                    string BrSpont_Fisherman_Friends = "-- Not Available --";
                    string BrSpont_Foxs = "-- Not Available --";
                    string BrSpont_Frozz = "-- Not Available --";
                    string BrSpont_Golia = "-- Not Available --";
                    string BrSpont_Gulas = "-- Not Available --";
                    string BrSpont_Hexos = "-- Not Available --";
                    string BrSpont_Hot_Hot_Pop = "-- Not Available --";
                    string BrSpont_Kapal_Api_Coffee_Candy = "-- Not Available --";
                    string BrSpont_Kis = "-- Not Available --";
                    string BrSpont_Kopiko = "-- Not Available --";
                    string BrSpont_Lazery = "-- Not Available --";
                    string BrSpont_Mentos = "-- Not Available --";
                    string BrSpont_Milkita = "-- Not Available --";
                    string BrSpont_MintZ = "-- Not Available --";
                    string BrSpont_Relaxa = "-- Not Available --";
                    string BrSpont_Strepsil = "-- Not Available --";
                    string BrSpont_Tamarin = "-- Not Available --";
                    string BrSpont_Yupi = "-- Not Available --";
                    string AdTom = "-- Not Available --";
                    string AdSpont_Alpenliebe = "-- Not Available --";
                    string AdSpont_Blaster = "-- Not Available --";
                    string AdSpont_Espresso = "-- Not Available --";
                    string AdSpont_Fisherman_Friends = "-- Not Available --";
                    string AdSpont_Foxs = "-- Not Available --";
                    string AdSpont_Frozz = "-- Not Available --";
                    string AdSpont_Golia = "-- Not Available --";
                    string AdSpont_Gulas = "-- Not Available --";
                    string AdSpont_Hexos = "-- Not Available --";
                    string AdSpont_Hot_Hot_Pop = "-- Not Available --";
                    string AdSpont_Kapal_Api_Coffee_Candy = "-- Not Available --";
                    string AdSpont_Kis = "-- Not Available --";
                    string AdSpont_Kopiko = "-- Not Available --";
                    string AdSpont_Lazery = "-- Not Available --";
                    string AdSpont_Mentos = "-- Not Available --";
                    string AdSpont_Milkita = "-- Not Available --";
                    string AdSpont_MintZ = "-- Not Available --";
                    string AdSpont_Relaxa = "-- Not Available --";
                    string AdSpont_Strepsil = "-- Not Available --";
                    string AdSpont_Tamarin = "-- Not Available --";
                    string AdSpont_Yupi = "-- Not Available --";
                    string Bumo = "-- Not Available --";
                    string Favourite_Brand = "-- Not Available --";
                    string ConL1M_Alpenliebe = "-- Not Available --";
                    string ConL1M_Blaster = "-- Not Available --";
                    string ConL1M_Espresso = "-- Not Available --";
                    string ConL1M_Fisherman_Friends = "-- Not Available --";
                    string ConL1M_Foxs = "-- Not Available --";
                    string ConL1M_Frozz = "-- Not Available --";
                    string ConL1M_Golia = "-- Not Available --";
                    string ConL1M_Gulas = "-- Not Available --";
                    string ConL1M_Hexos = "-- Not Available --";
                    string ConL1M_Hot_Hot_Pop = "-- Not Available --";
                    string ConL1M_Kapal_Api_Coffee_Candy = "-- Not Available --";
                    string ConL1M_Kis = "-- Not Available --";
                    string ConL1M_Kopiko = "-- Not Available --";
                    string ConL1M_Lazery = "-- Not Available --";
                    string ConL1M_Mentos = "-- Not Available --";
                    string ConL1M_Milkita = "-- Not Available --";
                    string ConL1M_MintZ = "-- Not Available --";
                    string ConL1M_Relaxa = "-- Not Available --";
                    string ConL1M_Strepsil = "-- Not Available --";
                    string ConL1M_Tamarin = "-- Not Available --";
                    string ConL1M_Yupi = "-- Not Available --";
                    string ConL3M_Alpenliebe = "-- Not Available --";
                    string ConL3M_Blaster = "-- Not Available --";
                    string ConL3M_Espresso = "-- Not Available --";
                    string ConL3M_Fisherman_Friends = "-- Not Available --";
                    string ConL3M_Foxs = "-- Not Available --";
                    string ConL3M_Frozz = "-- Not Available --";
                    string ConL3M_Golia = "-- Not Available --";
                    string ConL3M_Gulas = "-- Not Available --";
                    string ConL3M_Hexos = "-- Not Available --";
                    string ConL3M_Hot_Hot_Pop = "-- Not Available --";
                    string ConL3M_Kapal_Api_Coffee_Candy = "-- Not Available --";
                    string ConL3M_Kis = "-- Not Available --";
                    string ConL3M_Kopiko = "-- Not Available --";
                    string ConL3M_Lazery = "-- Not Available --";
                    string ConL3M_Mentos = "-- Not Available --";
                    string ConL3M_Milkita = "-- Not Available --";
                    string ConL3M_MintZ = "-- Not Available --";
                    string ConL3M_Relaxa = "-- Not Available --";
                    string ConL3M_Strepsil = "-- Not Available --";
                    string ConL3M_Tamarin = "-- Not Available --";
                    string ConL3M_Yupi = "-- Not Available --";
                    string ConL1W_Alpenliebe = "-- Not Available --";
                    string ConL1W_Blaster = "-- Not Available --";
                    string ConL1W_Espresso = "-- Not Available --";
                    string ConL1W_Fisherman_Friends = "-- Not Available --";
                    string ConL1W_Foxs = "-- Not Available --";
                    string ConL1W_Frozz = "-- Not Available --";
                    string ConL1W_Golia = "-- Not Available --";
                    string ConL1W_Gulas = "-- Not Available --";
                    string ConL1W_Hexos = "-- Not Available --";
                    string ConL1W_Hot_Hot_Pop = "-- Not Available --";
                    string ConL1W_Kapal_Api_Coffee_Candy = "-- Not Available --";
                    string ConL1W_Kis = "-- Not Available --";
                    string ConL1W_Kopiko = "-- Not Available --";
                    string ConL1W_Lazery = "-- Not Available --";
                    string ConL1W_Mentos = "-- Not Available --";
                    string ConL1W_Milkita = "-- Not Available --";
                    string ConL1W_MintZ = "-- Not Available --";
                    string ConL1W_Relaxa = "-- Not Available --";
                    string ConL1W_Strepsil = "-- Not Available --";
                    string ConL1W_Tamarin = "-- Not Available --";
                    string ConL1W_Yupi = "-- Not Available --";
                    string ConYestOrToday_Alpenliebe = "-- Not Available --";
                    string ConYestOrToday_Blaster = "-- Not Available --";
                    string ConYestOrToday_Espresso = "-- Not Available --";
                    string ConYestOrToday_Fisherman_Friends = "-- Not Available --";
                    string ConYestOrToday_Foxs = "-- Not Available --";
                    string ConYestOrToday_Frozz = "-- Not Available --";
                    string ConYestOrToday_Golia = "-- Not Available --";
                    string ConYestOrToday_Gulas = "-- Not Available --";
                    string ConYestOrToday_Hexos = "-- Not Available --";
                    string ConYestOrToday_Hot_Hot_Pop = "-- Not Available --";
                    string ConYestOrToday_Kapal_Api_Coffee_Candy = "-- Not Available --";
                    string ConYestOrToday_Kis = "-- Not Available --";
                    string ConYestOrToday_Kopiko = "-- Not Available --";
                    string ConYestOrToday_Lazery = "-- Not Available --";
                    string ConYestOrToday_Mentos = "-- Not Available --";
                    string ConYestOrToday_Milkita = "-- Not Available --";
                    string ConYestOrToday_MintZ = "-- Not Available --";
                    string ConYestOrToday_Relaxa = "-- Not Available --";
                    string ConYestOrToday_Strepsil = "-- Not Available --";
                    string ConYestOrToday_Tamarin = "-- Not Available --";
                    string ConYestOrToday_Yupi = "-- Not Available --";
                    string Nett_Mint_candy_TomAd = "-- Not Available --";
                    string Nett_Coffee_candy_TomAd = "-- Not Available --";
                    string Nett_Mint_candy_SpontAd = "-- Not Available --";
                    string Nett_Coffee_candy_SpontAd = "-- Not Available --";
                    string Nett_Mint_candy_TomBr = "-- Not Available --";
                    string Nett_Coffee_candy_TomBr = "-- Not Available --";
                    string Nett_Mint_candy_SpontBr = "-- Not Available --";
                    string Nett_Coffee_candy_SpontBr = "-- Not Available --";
                    string Nett_Mint_candy_Favourite = "-- Not Available --";
                    string Nett_Coffee_candy_Favourite = "-- Not Available --";
                    string Nett_Mint_candy_BUMO = "-- Not Available --";
                    string Nett_Coffee_candy_BUMO = "-- Not Available --";
                    string Nett_Mint_candy_ConsL3M = "-- Not Available --";
                    string Nett_Coffee_candy_ConsL3M = "-- Not Available --";
                    string Nett_Mint_candy_ConsL1M = "-- Not Available --";
                    string Nett_Coffee_candy_ConsL1M = "-- Not Available --";
                    string Nett_Mint_candy_ConsL1W = "-- Not Available --";
                    string Nett_Coffee_candy_ConsL1W = "-- Not Available --";
                    string Nett_Mint_candy_ConYestOrToday = "-- Not Available --";
                    string Nett_Coffee_candy_ConYestOrToday = "-- Not Available --";
                    string CA15 = "-- Not Available --";
                    string CA16 = "-- Not Available --";
                    string CA17 = "-- Not Available --";
                    string CA18 = "-- Not Available --";
                    string CA19 = "-- Not Available --";
                    string CA20 = "-- Not Available --";
                    string CA21 = "-- Not Available --";
                    string CA22 = "-- Not Available --";
                    string CA23 = "-- Not Available --";
                    string CA24 = "-- Not Available --";
                    string CA25 = "-- Not Available --";
                    string CA26 = "-- Not Available --";
                    string CA27 = "-- Not Available --";
                    string CA28 = "-- Not Available --";
                    string CA29 = "-- Not Available --";
                    string CA30 = "-- Not Available --";
                    string CA31 = "-- Not Available --";
                    string CA32 = "-- Not Available --";
                    string CA33 = "-- Not Available --";
                    string CA34 = "-- Not Available --";
                    string CA35 = "-- Not Available --";
                    string CA36 = "-- Not Available --";
                    string Seen_Ad = "-- Not Available --";
                    string CA38 = "-- Not Available --";
                    string CA41 = "-- Not Available --";
                    string CA42 = "-- Not Available --";
                    string CA43 = "-- Not Available --";
                    string CA44 = "-- Not Available --";
                    string S13_1 = "-- Not Available --";
                    string S13_2 = "-- Not Available --";
                    string S13_3 = "-- Not Available --";
                    string S13_4 = "-- Not Available --";
                    string S13_5 = "-- Not Available --";
                    string S13_6 = "-- Not Available --";
                    string P1M_Candy = "-- Not Available --";
                    string S13_8 = "-- Not Available --";
                    string S14_1 = "-- Not Available --";
                    string S14_2 = "-- Not Available --";
                    string S14_3 = "-- Not Available --";
                    string S14_4 = "-- Not Available --";
                    string S14_5 = "-- Not Available --";
                    string S14_6 = "-- Not Available --";
                    string P1W_Candy = "-- Not Available --";
                    string S14_8 = "-- Not Available --";
                    string T2B1_1 = "-- Not Available --";
                    string T2B1_2 = "-- Not Available --";
                    string T2B1_3 = "-- Not Available --";
                    string T2B1_4 = "-- Not Available --";
                    string T2B1_5 = "-- Not Available --";
                    string T2B1_6 = "-- Not Available --";
                    string T2B1_7 = "-- Not Available --";
                    string T2B1_8 = "-- Not Available --";
                    string T2B1_9 = "-- Not Available --";
                    string T2B1_10 = "-- Not Available --";
                    string CAJU37 = "-- Not Available --";
                    string CAJU38 = "-- Not Available --";

                    foreach (var variable in spssDataset.Variables)
                    {
                        foreach (string spss_v in spss_variable_name)
                        {
                            if (variable.Name.Equals(spss_v))
                            {
                                variable_name = variable.Name;

                                switch (variable_name)
                                {
                                    case "id":
                                        {
                                            u_id = Convert.ToString(record.GetValue(variable));
                                            userID = find_UserId(SurveyID, AttendedOn, u_id);
                                            break;
                                        }
                                    case "weight":
                                        {
                                            Weight = Convert.ToDecimal(record.GetValue(variable));
                                            break;
                                        }
                                    case "S9": { SES = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S8": { Location = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S2": { AgeGroup = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S7": { Gender = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S10": { MaritalStatus = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S11": { Occupation = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S12": { Education = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA6": { CA6 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA1": { BrTom = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_1": { BrSpont_Alpenliebe = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_2": { BrSpont_Blaster = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_3": { BrSpont_Espresso = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_4": { BrSpont_Fisherman_Friends = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_5": { BrSpont_Foxs = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_6": { BrSpont_Frozz = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_7": { BrSpont_Golia = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_8": { BrSpont_Gulas = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_9": { BrSpont_Hexos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_10": { BrSpont_Hot_Hot_Pop = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_11": { BrSpont_Kapal_Api_Coffee_Candy = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_12": { BrSpont_Kis = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_13": { BrSpont_Kopiko = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_14": { BrSpont_Lazery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_15": { BrSpont_Mentos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_16": { BrSpont_Milkita = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_17": { BrSpont_MintZ = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_18": { BrSpont_Relaxa = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_19": { BrSpont_Strepsil = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_20": { BrSpont_Tamarin = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_21": { BrSpont_Yupi = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA4": { AdTom = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_1": { AdSpont_Alpenliebe = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_2": { AdSpont_Blaster = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_3": { AdSpont_Espresso = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_4": { AdSpont_Fisherman_Friends = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_5": { AdSpont_Foxs = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_6": { AdSpont_Frozz = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_7": { AdSpont_Golia = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_8": { AdSpont_Gulas = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_9": { AdSpont_Hexos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_10": { AdSpont_Hot_Hot_Pop = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_11": { AdSpont_Kapal_Api_Coffee_Candy = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_12": { AdSpont_Kis = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_13": { AdSpont_Kopiko = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_14": { AdSpont_Lazery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_15": { AdSpont_Mentos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_16": { AdSpont_Milkita = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_17": { AdSpont_MintZ = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_18": { AdSpont_Relaxa = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_19": { AdSpont_Strepsil = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_20": { AdSpont_Tamarin = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_21": { AdSpont_Yupi = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA13": { Bumo = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA3": { Favourite_Brand = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_1": { ConL1M_Alpenliebe = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_2": { ConL1M_Blaster = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_3": { ConL1M_Espresso = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_4": { ConL1M_Fisherman_Friends = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_5": { ConL1M_Foxs = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_6": { ConL1M_Frozz = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_7": { ConL1M_Golia = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_8": { ConL1M_Gulas = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_9": { ConL1M_Hexos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_10": { ConL1M_Hot_Hot_Pop = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_11": { ConL1M_Kapal_Api_Coffee_Candy = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_12": { ConL1M_Kis = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_13": { ConL1M_Kopiko = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_14": { ConL1M_Lazery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_15": { ConL1M_Mentos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_16": { ConL1M_Milkita = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_17": { ConL1M_MintZ = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_18": { ConL1M_Relaxa = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_19": { ConL1M_Strepsil = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_20": { ConL1M_Tamarin = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_21": { ConL1M_Yupi = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_1": { ConL3M_Alpenliebe = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_2": { ConL3M_Blaster = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_3": { ConL3M_Espresso = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_4": { ConL3M_Fisherman_Friends = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_5": { ConL3M_Foxs = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_6": { ConL3M_Frozz = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_7": { ConL3M_Golia = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_8": { ConL3M_Gulas = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_9": { ConL3M_Hexos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_10": { ConL3M_Hot_Hot_Pop = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_11": { ConL3M_Kapal_Api_Coffee_Candy = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_12": { ConL3M_Kis = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_13": { ConL3M_Kopiko = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_14": { ConL3M_Lazery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_15": { ConL3M_Mentos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_16": { ConL3M_Milkita = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_17": { ConL3M_MintZ = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_18": { ConL3M_Relaxa = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_19": { ConL3M_Strepsil = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_20": { ConL3M_Tamarin = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_21": { ConL3M_Yupi = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_1": { ConL1W_Alpenliebe = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_2": { ConL1W_Blaster = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_3": { ConL1W_Espresso = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_4": { ConL1W_Fisherman_Friends = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_5": { ConL1W_Foxs = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_6": { ConL1W_Frozz = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_7": { ConL1W_Golia = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_8": { ConL1W_Gulas = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_9": { ConL1W_Hexos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_10": { ConL1W_Hot_Hot_Pop = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_11": { ConL1W_Kapal_Api_Coffee_Candy = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_12": { ConL1W_Kis = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_13": { ConL1W_Kopiko = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_14": { ConL1W_Lazery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_15": { ConL1W_Mentos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_16": { ConL1W_Milkita = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_17": { ConL1W_MintZ = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_18": { ConL1W_Relaxa = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_19": { ConL1W_Strepsil = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_20": { ConL1W_Tamarin = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_21": { ConL1W_Yupi = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_1": { ConYestOrToday_Alpenliebe = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_2": { ConYestOrToday_Blaster = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_3": { ConYestOrToday_Espresso = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_4": { ConYestOrToday_Fisherman_Friends = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_5": { ConYestOrToday_Foxs = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_6": { ConYestOrToday_Frozz = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_7": { ConYestOrToday_Golia = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_8": { ConYestOrToday_Gulas = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_9": { ConYestOrToday_Hexos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_10": { ConYestOrToday_Hot_Hot_Pop = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_11": { ConYestOrToday_Kapal_Api_Coffee_Candy = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_12": { ConYestOrToday_Kis = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_13": { ConYestOrToday_Kopiko = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_14": { ConYestOrToday_Lazery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_15": { ConYestOrToday_Mentos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_16": { ConYestOrToday_Milkita = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_17": { ConYestOrToday_MintZ = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_18": { ConYestOrToday_Relaxa = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_19": { ConYestOrToday_Strepsil = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_20": { ConYestOrToday_Tamarin = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_21": { ConYestOrToday_Yupi = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA4_Net1": { Nett_Mint_candy_TomAd = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA4_Net2": { Nett_Coffee_candy_TomAd = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_Net1": { Nett_Mint_candy_SpontAd = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA8_Net2": { Nett_Coffee_candy_SpontAd = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA1_Net1": { Nett_Mint_candy_TomBr = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA1_Net2": { Nett_Coffee_candy_TomBr = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_Net1": { Nett_Mint_candy_SpontBr = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA2_Net2": { Nett_Coffee_candy_SpontBr = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA13_Net1": { Nett_Mint_candy_BUMO = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA13_Net2": { Nett_Coffee_candy_BUMO = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA3_Net1": { Nett_Mint_candy_Favourite = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA3_Net2": { Nett_Coffee_candy_Favourite = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_Net1": { Nett_Mint_candy_ConsL3M = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA9_Net2": { Nett_Coffee_candy_ConsL3M = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_Net1": { Nett_Mint_candy_ConsL1M = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA10_Net2": { Nett_Coffee_candy_ConsL1M = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_Net1": { Nett_Mint_candy_ConsL1W = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA11_Net2": { Nett_Coffee_candy_ConsL1W = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_Net1": { Nett_Mint_candy_ConYestOrToday = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA12_Net2": { Nett_Coffee_candy_ConYestOrToday = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA15": { CA15 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA16": { CA16 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA17": { CA17 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA18": { CA18 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA19": { CA19 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA20": { CA20 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA21": { CA21 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA22": { CA22 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA23": { CA23 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA24": { CA24 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA25": { CA25 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA26": { CA26 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA27": { CA27 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA28": { CA28 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA29": { CA29 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA30": { CA30 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA31": { CA31 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA32": { CA32 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA33": { CA33 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA34": { CA34 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA35": { CA35 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C36": { CA36 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA37": { Seen_Ad = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA38": { CA38 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA41": { CA41 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA42": { CA42 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA43": { CA43 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CA44": { CA44 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S13_1": { S13_1 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S13_2": { S13_2 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S13_3": { S13_3 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S13_4": { S13_4 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S13_5": { S13_5 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S13_6": { S13_6 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S13_7": { P1M_Candy = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S13_8": { S13_8 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S14_1": { S14_1 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S14_2": { S14_2 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S14_3": { S14_3 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S14_4": { S14_4 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S14_5": { S14_5 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S14_6": { S14_6 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S14_7": { P1W_Candy = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S14_8": { S14_8 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_1": { T2B1_1 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_2": { T2B1_2 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_3": { T2B1_3 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_4": { T2B1_4 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_5": { T2B1_5 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_6": { T2B1_6 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_7": { T2B1_7 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_8": { T2B1_8 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_9": { T2B1_9 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "T2B1_10": { T2B1_10 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CAJU37": { CAJU37 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "CAJU38": { CAJU38 = Convert.ToString(record.GetValue(variable)); break; }
                                }
                            }
                        }
                    }
                    if (userID != null && Weight != 0 && AgeGroup.Equals("3") || AgeGroup.Equals("4") || AgeGroup.Equals("5"))
                    {
                        iobj.insert_Dashboard_values(userID, SurveyID, AttendedOn, Weight, country, Location, Gender, MaritalStatus, Occupation, Education, AgeGroup, SES, CA6, BrTom, BrSpont_Alpenliebe, BrSpont_Blaster, BrSpont_Espresso, BrSpont_Fisherman_Friends, BrSpont_Foxs, BrSpont_Frozz, BrSpont_Golia, BrSpont_Gulas, BrSpont_Hexos, BrSpont_Hot_Hot_Pop, BrSpont_Kapal_Api_Coffee_Candy, BrSpont_Kis, BrSpont_Kopiko, BrSpont_Lazery, BrSpont_Mentos, BrSpont_Milkita, BrSpont_MintZ, BrSpont_Relaxa, BrSpont_Strepsil, BrSpont_Tamarin, BrSpont_Yupi, AdTom, AdSpont_Alpenliebe, AdSpont_Blaster, AdSpont_Espresso, AdSpont_Fisherman_Friends, AdSpont_Foxs, AdSpont_Frozz, AdSpont_Golia, AdSpont_Gulas, AdSpont_Hexos, AdSpont_Hot_Hot_Pop, AdSpont_Kapal_Api_Coffee_Candy, AdSpont_Kis, AdSpont_Kopiko, AdSpont_Lazery, AdSpont_Mentos, AdSpont_Milkita, AdSpont_MintZ, AdSpont_Relaxa, AdSpont_Strepsil, AdSpont_Tamarin, AdSpont_Yupi, Bumo, Favourite_Brand, ConL1M_Alpenliebe, ConL1M_Blaster, ConL1M_Espresso, ConL1M_Fisherman_Friends, ConL1M_Foxs, ConL1M_Frozz, ConL1M_Golia, ConL1M_Gulas, ConL1M_Hexos, ConL1M_Hot_Hot_Pop, ConL1M_Kapal_Api_Coffee_Candy, ConL1M_Kis, ConL1M_Kopiko, ConL1M_Lazery, ConL1M_Mentos, ConL1M_Milkita, ConL1M_MintZ, ConL1M_Relaxa, ConL1M_Strepsil, ConL1M_Tamarin, ConL1M_Yupi, ConL3M_Alpenliebe, ConL3M_Blaster, ConL3M_Espresso, ConL3M_Fisherman_Friends, ConL3M_Foxs, ConL3M_Frozz, ConL3M_Golia, ConL3M_Gulas, ConL3M_Hexos, ConL3M_Hot_Hot_Pop, ConL3M_Kapal_Api_Coffee_Candy, ConL3M_Kis, ConL3M_Kopiko, ConL3M_Lazery, ConL3M_Mentos, ConL3M_Milkita, ConL3M_MintZ, ConL3M_Relaxa, ConL3M_Strepsil, ConL3M_Tamarin, ConL3M_Yupi, ConL1W_Alpenliebe, ConL1W_Blaster, ConL1W_Espresso, ConL1W_Fisherman_Friends, ConL1W_Foxs, ConL1W_Frozz, ConL1W_Golia, ConL1W_Gulas, ConL1W_Hexos, ConL1W_Hot_Hot_Pop, ConL1W_Kapal_Api_Coffee_Candy, ConL1W_Kis, ConL1W_Kopiko, ConL1W_Lazery, ConL1W_Mentos, ConL1W_Milkita, ConL1W_MintZ, ConL1W_Relaxa, ConL1W_Strepsil, ConL1W_Tamarin, ConL1W_Yupi, ConYestOrToday_Alpenliebe, ConYestOrToday_Blaster, ConYestOrToday_Espresso, ConYestOrToday_Fisherman_Friends, ConYestOrToday_Foxs, ConYestOrToday_Frozz, ConYestOrToday_Golia, ConYestOrToday_Gulas, ConYestOrToday_Hexos, ConYestOrToday_Hot_Hot_Pop, ConYestOrToday_Kapal_Api_Coffee_Candy, ConYestOrToday_Kis, ConYestOrToday_Kopiko, ConYestOrToday_Lazery, ConYestOrToday_Mentos, ConYestOrToday_Milkita, ConYestOrToday_MintZ, ConYestOrToday_Relaxa, ConYestOrToday_Strepsil, ConYestOrToday_Tamarin, ConYestOrToday_Yupi, Nett_Mint_candy_TomAd, Nett_Coffee_candy_TomAd, Nett_Mint_candy_SpontAd, Nett_Coffee_candy_SpontAd, Nett_Mint_candy_TomBr, Nett_Coffee_candy_TomBr, Nett_Mint_candy_SpontBr, Nett_Coffee_candy_SpontBr, Nett_Mint_candy_Favourite, Nett_Coffee_candy_Favourite, Nett_Mint_candy_BUMO, Nett_Coffee_candy_BUMO, Nett_Mint_candy_ConsL3M, Nett_Coffee_candy_ConsL3M, Nett_Mint_candy_ConsL1M, Nett_Coffee_candy_ConsL1M, Nett_Mint_candy_ConsL1W, Nett_Coffee_candy_ConsL1W, Nett_Mint_candy_ConYestOrToday, Nett_Coffee_candy_ConYestOrToday, CA15, CA16, CA17, CA18, CA19, CA20, CA21, CA22, CA23, CA24, CA25, CA26, CA27, CA28, CA29, CA30, CA31, CA32, CA33, CA34, CA35, CA36, Seen_Ad, CA38, CA41, CA42, CA43, CA44, S13_1, S13_2, S13_3, S13_4, S13_5, S13_6, P1M_Candy, S13_8, S14_1, S14_2, S14_3, S14_4, S14_5, S14_6, P1W_Candy, S14_8, T2B1_1, T2B1_2, T2B1_3, T2B1_4, T2B1_5, T2B1_6, T2B1_7, T2B1_8, T2B1_9, T2B1_10, CAJU37, CAJU38);
                    }
                }
            }
        }

        private static string find_UserId(int SurveyID, string SurveyPeriod, string u_id)
        {
            string sum = "";
            string[] date = SurveyPeriod.Split('-');
            foreach (string d in date)
            {
                sum = sum + d;

            }
            return u_id + SurveyID + sum;
        }
    }
}
