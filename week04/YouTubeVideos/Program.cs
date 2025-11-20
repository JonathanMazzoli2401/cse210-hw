using System;
using System.Runtime.Intrinsics;

public class Program
{
    public static void Main(string[] args){
        List<Video> videos = new List<Video>();

        Video v1 = new Video("How to Make Uruguayan Mate", "Jonathan Mazzoli", 320);
        v1.AddComment(new Comment("Ana", "Excelent explanation!, very clear."));
        v1.AddComment(new Comment("Carlos", "I never thought it would be so easy."));
        v1.AddComment(new Comment("Lucia", "Could you make one with different types of yerba?"));

        Video v2 = new Video("What is Encapsulation in C#", "Tech Guru", 540);
        v2.AddComment(new Comment("Marcos", "The best video I found on the subject."));
        v2.AddComment(new Comment("Elena", "Thank you, it helped me for my class."));
        v2.AddComment(new Comment("Roberto", "Very professional explanation."));

        Video v3 = new Video("Football Highlights: Uruguay vs Chile", "Sports Media", 410);
        v3.AddComment(new Comment("Pedro", "What a game!"));
        v3.AddComment(new Comment("Sofía", "Valverde machine."));
        v3.AddComment(new Comment("Ignacio", "Great goals. What a good summary."));

        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        foreach (Video video in videos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Commenter}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}