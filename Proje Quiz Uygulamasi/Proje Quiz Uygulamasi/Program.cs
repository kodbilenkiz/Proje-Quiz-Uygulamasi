using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static Random _random = new Random(); //Rastgele Metod

    public class Question
    {
        public List<string> Answers = new List<string>(4);
        public int RightAnswer;
        public string QuestionText;
    }

    public static void Main(string[] args)
    {
        int questionCount; // Soru sayısı
        int questionPoint; // Soruların puanı
        int totalPoint = 0; // Toplam Puan
        int rightAnswerCount = 0; // Doğru cevap sayısı
        int wrongAnswerCount = 0; // Yanlış cevap sayısı
        List<Question> questions = new List<Question>(10);
        // Fill Data
        FillData(questions);
        // Shuffle Data
        Shuffle(questions);
        Console.WriteLine("Quiz uygulamasına hoş geldiniz. Quiz kaç sorudan oluşsun? (Soru havuzumuz {0} sorudan oluşmaktadır.)", questions.Count);
        questionCount = GetQuestionCount(questions);
        questionPoint = GetPoint();
        StartQuiz(questionCount, questionPoint, ref totalPoint, ref rightAnswerCount, ref wrongAnswerCount, questions);
        WriteResult(totalPoint, rightAnswerCount, wrongAnswerCount);
        Console.ReadLine();
    }

    private static void StartQuiz(int questionCount, int questionPoint, ref int totalPoint, ref int rightAnswerCount, ref int wrongAnswerCount, List<Question> questions)
    {
        Console.WriteLine("Quiziniz hazır. Haydi başlayalım!\n");
        for (int j = 0; j < questionCount; j++)
        {
            Console.WriteLine(questions[j].QuestionText);
            Console.WriteLine("A-)" + questions[j].Answers[0] + "     B-)" + questions[j].Answers[1] + "     C-)" + questions[j].Answers[2] + "     D-)" + questions[j].Answers[3]);
            int answer = -1;
            do
            {
                Console.WriteLine("Cevabınız (A,B,C,D) : ");
                answer = ConvertToNumber(Console.ReadLine());
                if (answer == -1)
                {
                    Console.WriteLine("Geçersiz bir cevap girdiniz. Lütfen tekrar deneyiniz!");
                }
            }
            while (answer == -1);
            if (answer == questions[j].RightAnswer)
            {
                Console.WriteLine("Tebrikler, cevabınız doğru!");
                totalPoint += questionPoint;
                rightAnswerCount++;
            }
            else
            {
                Console.WriteLine("Cevabınız yanlış,sorunun doğru cevabı: " + questions[j].Answers[questions[j].RightAnswer]);
                wrongAnswerCount++;
            }

            Console.WriteLine("\n");
        }
    }

    private static int GetPoint()
    {
        int pointCountCheck;
        bool checkTrueFalse = true;
        do
        {
            checkTrueFalse = true;
            Console.WriteLine("Her soru kaç puan olsun? (100'den küçük ve pozitif bir değer giriniz.)");
            pointCountCheck = Convert.ToInt32(Console.ReadLine());
            if ((pointCountCheck > 100) || (pointCountCheck <= 0))
            {
                Console.WriteLine("Geçersiz bir puan girdiniz.");
                checkTrueFalse = false;
            }
        }
        while (!checkTrueFalse);
        return pointCountCheck;
    }

    private static int ConvertToNumber(string harfCevap)
    {
        int result = -1;
        if (!string.IsNullOrWhiteSpace(harfCevap)) // https://msdn.microsoft.com/tr-tr/library/system.string.isnullorwhitespace(v=vs.110).aspx
        {
            harfCevap = harfCevap.ToUpper();
            switch (harfCevap)
            {
                case "A":
                    {
                        result = 0;
                        break;
                    }

                case "B":
                    {
                        result = 1;
                        break;
                    }

                case "C":
                    {
                        result = 2;
                        break;
                    }

                case "D":
                    {
                        result = 3;
                        break;
                    }
            }
        }

        return result;
    }

    private static int GetQuestionCount(List<Question> questions)
    {
        int questionCount = 0;
        bool checkTrueFalse2 = true;
        do
        {
            checkTrueFalse2 = true;
            // burada hata kontrolü yapılmalı, kullanıcı sayı yerine harf veya boşluk veya hiç bir şey girmeden enter'a basabilir !! HATA İLE KARŞILAŞILIYOR
            questionCount = Convert.ToInt32(Console.ReadLine());
            if ((questionCount > questions.Count) || (questionCount <= 0))
            {
                Console.WriteLine("Geçersiz soru sayısı girdiniz.");
                checkTrueFalse2 = false;
            }
        }
        while (!checkTrueFalse2);
        return questionCount;
    }

    private static void WriteResult(int totalPoint, int rightAnswerCount, int wrongAnswerCount)
    {
        Console.WriteLine("Bütün soruları tamamladınız.Sonuçlarınızı aşağıda bulabilirsiniz:");
        Console.WriteLine("Puanınız : " + totalPoint);
        Console.WriteLine("Doğru sayınız : " + rightAnswerCount);
        Console.WriteLine("Yanlış sayınız: " + wrongAnswerCount);
        Console.WriteLine("\n Testimize katıldığınız için teşekkürler! ^^");
        Console.WriteLine("Çıkmak için herhangi bir tuşa basınız.");
    }

    private static void FillData(List<Question> questions)
    {
        //Array dizisi kullanmak yerine List kullanarak daha az bir kod yapısı sağlandı. *
        AddQuestion(questions,
            "DotA isimli MOBA oyununun açılımı nedir? ",
            2, //Cevap seçeneğini belirtir.
            "Defense of the Arkham",
            "Defence of the Ancients",
            "Defense of the Ancients",
            "Dance of the Architectures"
            );
        AddQuestion(questions,
            "League of Legends oyununda 'Üzgün Mumya' lakaplı şampiyonun adı nedir?",
            2,
            "Leona",
            "Skarner",
            "Amumu",
            "Sivir"
            );
        AddQuestion(questions,
            "Doctor Who adlı bilim kurgu dizisinin 12.Doktor'unu canlandıran aktörün adı nedir?",
            3,
            "Matt Smith",
            "Tom Baker",
            "David Tennant",
            "Peter Capaldi"
            );
        AddQuestion(questions,
            "Person Of Interest adlı dizide Harold Finch'in yarattığı yapay zeka 'Makine'nin düşmanı yapay zekanın adı nedir?",
            1,
            "Root",
            "Samaritan",
            "Hope",
            "Reese"
            );
        AddQuestion(questions,
            "YouTUBE adlı sitede en fazla abonesi olan kanal hangisidir?",
            0,
            "PewDiePie",
            "Oha Diyorum",
            "Markiplier",
            "DoctorWho.web.tr" 
            );
        AddQuestion(questions,
            "YouTUBE'da en çok 'bunu beğenmedim' butonuna tıklanan oyun tanıtım videosu hangi oyuna aittir?",
            2,
            "Assassin's Creed Syndicate",
            "Battlefield 1",
            "Call Of Duty Infinite Warfare",
            "DOOM"
            );
        AddQuestion(questions,
            "Dünyaca ünlü sosyal ağ Facebook'un kurucusu kimdir?",
            0,
            "Mark Zuckerberg",
            "Çağatay Karahan", 
            "Steve Jobs",
            "Bill Gates"
            );
        AddQuestion(questions,
            "Kullanıcılarının paylaştıklarını 140 karakterde sınırlayan sosyal ağ hangisidir?",
            3,
            "Instagram",
            "Reddit",
            "Scorp",
            "Twitter"
            );
        AddQuestion(questions,
            "Çizgi romanında kendi yazarlarını öldüren çizgi roman anti-kahramanı kimdir?",
            1,
            "Batman", 
            "Deadpool",
            "Joker",
            "Wolverine"
            );
        AddQuestion(questions,
            "'Ve şunu bilmelisin ki, insanı öldürmeyen şey tuhaflaştırır.' sözü hangi karaktere aittir?",
            2,
            "Harley Quinn",
            "Batman",
            "Joker",
            "Robin"
            );

    }

    //private static void AddQuestion(List<Question> questions, string questionText, int rightAnswer, params string[] answers)
    // yukarıdaki şekilde de kullanılabilir, ancak iç tarafta cevap sayısı sabit olduğu için kontrol yapılmalı
    // if(answers.Length > 4)
    // return;
    // tabi return çok mantıklı değil
    private static void AddQuestion(List<Question> questions, string questionText, int rightAnswer, string answer1, string answer2, string answer3, string answer4)
    {
        int currentIndex = questions.Count;
        Question question = new Question();
        question.QuestionText = questionText;
        question.Answers.Add(answer1);
        question.Answers.Add(answer2);
        question.Answers.Add(answer3);
        question.Answers.Add(answer4);
        question.RightAnswer = rightAnswer;
        questions.Add(question);
    }

    private static void Shuffle(List<Question> List)
    {
        var randomOrderList = List.OrderBy(o => Guid.NewGuid().ToString()).ToList(); /* stackoverflow */

        for (int i = 0; i < List.Count; i++)
        {
            List[i] = randomOrderList[i];
        }
    }
   
}
