# Proje - Quiz Uygulaması

Amaç: Konsol üzerinden çalışan bir quiz uygulaması geliştirmek.

# Yapılması gerekenler:
  - En az 10-20 arası sayıda sorudan oluşan bir soru havuzu +
  - Program açıldıktan sonra yapılması gerekenler:
  - Kullanıcıya quizin kaç sorudan oluşacağını sormak ( Soru havuzunun miktarı belirtilmeli) +
  - Her sorunun kaç puandan oluşacağını sormak (0-100 arasında) +
  - Girilen soru sayısı değerinin soru havuzu boyutunu aşmayacak ve negatif bir sayı olmayacak +
  - Puan değeri de 0 ile 100 arasında olacak(Girilen değerin sayı olduğu varsayılacak) + (Extra eklenebilir-)
  - Alınan verilerden sonra istenilen miktarda soruyu kullanıcıyı sıra ile sorulacak. +
  - **UYGULAMA HER ÇALIŞTIRILDIĞINDA SORULAR RASTGELE SORULACAK**  ++ Shuffle
  - Yanlış cevap verildiğinde içerik ile doğru cevap kullanıcıya gösterilecek.
  - Doğru cevap verildiğinde tebrik edilip bir sonraki soruya geçilecek.
  - **Quiz sonunda alınan puan, doğru ve yanlış cevap sayıları ekrana yazılıp program sonlandırılacak**.


 #Araştırma:
 -Kaynak: http://stackoverflow.com/questions/273313/randomize-a-listt)
 -Rastgele soruların çıkması kullanılan metot : http://www.dotnetperls.com/shuffle
 -Ayrıntılı bilgi için bkz. https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle (Fisher–Yates shuffle)
 -IsNullOrWhiteSpace yapısı: https://msdn.microsoft.com/tr-tr/library/system.string.isnullorwhitespace(v=vs.110).aspx
 -Guid.NewGuid() yapısı kullanma >https://msdn.microsoft.com/tr-tr/library/system.guid.newguid(v=vs.110).aspx
 -var yapısı https://msdn.microsoft.com/tr-tr/library/bb383973.aspx
 -Guid içinde kullanılan var yapısı stackoverflow'dan araştırma yapılarak bulundu.

Karşılaşılan problem
 private static void Shuffle(List<Question> List)
{
    List = List.OrderBy(o => Guid.NewGuid().ToString()).ToList();
    foreach (Question question in ....) { Console.WriteLine(question);
}
