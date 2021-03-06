using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }
    [SampleCode("Chapter 8")]
    class SampleCode  {

        [ListNo("List 8-14")]
        public void CompareDatetime() {
            var dt1 = new DateTime(2006, 10, 18, 1, 30, 21);
            var dt2 = new DateTime(2006, 11, 2, 18, 5, 28);
            if (dt1 < dt2)
                Console.WriteLine("dt2の方が新しい日時です");
            else if (dt1 == dt2)
                Console.WriteLine("dt1とdt2は同じ日時です");
        }

        [ListNo("List 8-15")]
        public void CompareDate() {
            var dt1 = new DateTime(2001, 10, 25, 1, 30, 21);
            var dt2 = new DateTime(2001, 10, 25, 18, 5, 28);
            if (dt1.Date < dt2.Date)
                Console.WriteLine("dt2の方が新しい日にちです");
            else if (dt1.Date == dt2.Date)
                Console.WriteLine("dt1とdt2は、同じ日にちです");
        }

    }
}
