using EntryPoint;
using System;
using _2024ProconTemporary.ReadableData;
using _2024ProconTemporary.Com;
using _2024ProconTemporary;
using System.Linq;


namespace _2024ProconTemporary.CommandLine.Commands
{
    public class BootCommandClient : BaseCliArguments
    {
        public BootCommandClient() : base("Initialize Command") { }

        [OptionParameter(ShortName: 'v', LongName: "view")]
        [Help("問題データを表示します")]
        public bool isView { get; set; }

        [OptionParameter(ShortName: 'm', LongName: "manual")]
        [Help("手動で回答を作成するモードに移行します")]
        public bool isManual { get; set; }
    }

    public class BootCommand
    {
        public async void Handle(BootCommandClient args)
        {
            Console.WriteLine("Booting...");

            // 問題データを取得する
            Console.WriteLine("Getting Problem Data...");
            HttpClient client = Networking.CreateClient();
            var problemData = await Networking.GetProblemDataAsync(client);

            if (problemData == null)
            {
                Console.WriteLine("ERROR: ProblemData Download Failed!");
                Console.WriteLine("Please check your network connection and try again.");
                return;
            }
            Console.WriteLine("Done!");

            // 問題データ、回答データをstringの配列からintの2次元配列に変換する
            ReadableProblemData convertedProblemData = new ReadableProblemData(problemData);

            // 問題データを表示する
            if (args.isView)
            {
                Console.WriteLine("Problem Data:");
                Console.WriteLine(problemData.ToString());
            }

            AnswerData answerData = Answer.Create();

            // 手動で回答を作成するモードに移行する
            if (args.isManual)
            {
                Console.WriteLine("Manual Mode");
                Console.WriteLine("Please input answer.");
                ManualMode(problemData);
            }

            else
            {
                // 自動回答モードに移行する
                Console.WriteLine("Automatic Mode");
                Console.WriteLine("Calculating Answer...");
                MainAlgorithm.MatchCalculate();

                Console.WriteLine("Done!");

                // 回答結果を表示する(間違っている場所、かかった手数など)
                CompareAnswers(problemData, answerData);


                // これで提出するか聞く
                Console.WriteLine("Do you want to submit this answer? (Y/n)");
                string input = Console.ReadLine() ?? "";

                if (input == "N" || input == "n")
                {
                    // 手動で回答を作成するモードに移行する
                    Console.WriteLine("transit to Manual Mode");
                    answerData = ManualMode(problemData);
                }

                // 回答を提出する
                Console.WriteLine("Submitting Answer...");
                await Networking.SendAnswerDataAsync(client, answerData);
                Console.WriteLine("Done!");

            }


        }

        AnswerData ManualMode(ProblemData problemData, AnswerData answerData = null)
        {
            if (answerData == null) answerData = Answer.Create();

            Console.WriteLine("Manual Mode");
            Console.WriteLine("Please input answer.");

            // キー入力を受付、回答を作成する
            while (true)
            {
                Console.WriteLine("Please press key...");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    // 終了
                    Console.WriteLine("Exit Manual Mode");
                    break;
                }

                else if (key.Key == ConsoleKey.H)
                {
                    // ヘルプを表示
                    Console.WriteLine("Help");
                }

                else if (key.Key == ConsoleKey.Enter)
                {

                }

            }


            return answerData;

        }

        void CompareAnswers(ProblemData problemData, AnswerData answerData)
        {

        }
    }


}