using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 12")]
    class SampleCode  {

        [ListNo("List 12-15")]
        public void Serialize() {
            var novels = new Novel[] {
              new Novel {
                Author = "アイザック・アシモフ",
                Title = "われはロボット",
                Published = 1950,
              },
              new Novel {
                Author = "ジョージ・オーウェル",
                Title = "一九八四年",
                Published = 1949,
              },
            };
            using (var stream = new FileStream("novels.json", FileMode.Create,
                                                FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(novels.GetType());
                serializer.WriteObject(stream, novels);
            }

            Display("novels.json");
        }
        private static string SerializeToString() {
            var novels = new Novel[] {
              new Novel {
                Author = "アイザック・アシモフ",
                Title = "われはロボット",
                Published = 1950,
              },
              new Novel {
                Author = "ジョージ・オーウェル",
                Title = "一九八四年",
                Published = 1949,
              },
            };
            using (var stream = new MemoryStream()) {
                var serializer = new DataContractJsonSerializer(novels.GetType());
                serializer.WriteObject(stream, novels);
                stream.Close();
                var jsonText = Encoding.UTF8.GetString(stream.ToArray());
                return jsonText;
            }
        }

        [ListNo("List 12-16")]
        public void Deserialize() {
            using (var stream = new FileStream("novels.json", FileMode.Open, FileAccess.Read)) {
                var serializer = new DataContractJsonSerializer(typeof(Novel[]));
                var novels = serializer.ReadObject(stream) as Novel[];
                foreach (var novel in novels)
                    Console.WriteLine(novel);
            }
        }

        public void DeserializeFromString() {
            var jsonText = SerializeToString();
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonText);
            using (var stream = new MemoryStream(byteArray)) {
                var serializer = new DataContractJsonSerializer(typeof(Novel[]));
                var novels = serializer.ReadObject(stream) as Novel[];
                foreach (var novel in novels)
                    Console.WriteLine(novel);
            }
        }


        [ListNo("List 12-17")]
        public void SerializeDict() {
            var abbreviationDict = new AbbreviationDict {
                Abbreviations = new Dictionary<string, string> {
                    ["ODA"] = "政府開発援助",
                    ["OECD"] = "経済協力開発機構",
                    ["OPEC"] = "石油輸出国機構",
                }
            };
            var settings = new DataContractJsonSerializerSettings {
                UseSimpleDictionaryFormat = true,
            };
            using (var stream = new FileStream("abbreviations.json", FileMode.Create, FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(abbreviationDict.GetType(), settings);
                serializer.WriteObject(stream, abbreviationDict);
            }

            Display("abbreviations.json");
        }


        [ListNo("List 12-18")]
        public void DeserializeDict() {
            var settings = new DataContractJsonSerializerSettings {
                UseSimpleDictionaryFormat = true,
            };
            using (var stream = new FileStream("abbreviations.json", FileMode.Open, FileAccess.Read)) {
                var serializer = new DataContractJsonSerializer(typeof(AbbreviationDict), settings);
                var dict = serializer.ReadObject(stream) as AbbreviationDict;
                foreach (var item in dict.Abbreviations) {
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
                }
            }
        }

        private void Display(string filename) {
            var lines = File.ReadLines(filename);
            foreach (var line in lines)
                Console.WriteLine(line);

        }


    }
}
