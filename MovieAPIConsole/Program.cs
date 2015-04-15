/*-----------------------------------------------------------------------------
 Programmer:  Andrew Douglas
 
 Program:     Rotten Tomatoes API - Hits the Rotten Tomatoes API after prompting
              the user for a movie title.  Then parses the JSON response and 
              creates a HTML file containing the parsed response.
  
 Course:      CSS 405 - Web Programming
 
 Instructor:  Tom Rishel
 -----------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MovieConsole
{
    class Program
    {
        
        public static string movieTitle;                  //declaration of variable for the program
        public static int year; 
        public static string MPAArating;
        public static int criticScore;     
        public static string criticRating;
        public static int audienceScore;
        public static string audienceRating;
        public static string synopsis;
        public static string cast1;
        public static string cast2;
        public static string cast3;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a movie title");             //prompt for movie title
            movieTitle = Console.ReadLine();                             //store in movie title
            movieTitle = movieTitle.Replace(' ', '+');             //convert blank spaces in title to plus signs   
            
           
             
            MovieApiClient.GetMovieInfo();

            //header of the html document
            string header = "<html><head><link href=\"movies.css\" rel=\"stylesheet\" type=\"text/css\" />" + "</head><body><h1>" + movieTitle + "</h1><table>" +
                "<colgroup><col class=\"info\" span=\"6\"/><thead><tr><th>Year</th><th>Rating</th><th>Critic Score</th><th>Critic Rating</th><th>Audience Score</th><th>Audience Rating</th>"+ 
                "</tr>";
            //body fo the html document
            string body = "<td>" + year + "</td><td>" + MPAArating + "</td><td>" + criticScore +"</td><td>" + criticRating + "</td>" +
                "<td>" + audienceScore + "</td><td>" + audienceRating + "</td> </table>";
            //cast inserted into the document
            string cast = "<h2>Starring:</h2><div id=\"cast\"><br>" + cast1 + "<br>" + cast2 + "<br>" + cast3 +"</div>";
            //end of the html
            string tail = "<p>" + synopsis + "</p></body></html>";
            //adds all of the html together
            string everything = header + body + cast + tail;
            //prints the html into a file called movieData
            using (StreamWriter outfile = new StreamWriter(@"C:\Users\Andrew\Documents\movieData.htm"))
            {
                outfile.Write(everything);
            }


    
        }
    }
}
