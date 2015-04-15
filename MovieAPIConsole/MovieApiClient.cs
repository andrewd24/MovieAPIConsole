/*-----------------------------------------------------------------------------
 *MovieAPIClient.cs
 * 
 *Hits the Rotten Tomatoes API and catches the JSON response.  Passes the JSON 
 *to the MovieData class for serialization.
 ----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;

namespace MovieConsole
{
    public static class MovieApiClient
    {
        public static void GetMovieInfo()
        {
            var url = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey=a677j8k8uajxetap8rvgu7kq&q="+ Program.movieTitle + "&page_limit=1"; //url to pull the weather data from

            var syncClient = new WebClient();                                                         
            var content = syncClient.DownloadString(url);
            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MovieData));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                var movieInfo = (MovieData)serializer.ReadObject(ms);
               
               Program.movieTitle = movieInfo.movies[0].title;                             //sets the movie title
               Program.year = movieInfo.movies[0].year;                                    //sets the year
               Program.MPAArating = movieInfo.movies[0].mpaa_rating;                       //motion picture rating
               Program.criticScore = movieInfo.movies[0].ratings.critics_score;            //critic numerical score
               Program.criticRating = movieInfo.movies[0].ratings.critics_rating;          //critic text score
               Program.audienceScore = movieInfo.movies[0].ratings.audience_score;         //audience numerical score
               Program.audienceRating = movieInfo.movies[0].ratings.audience_rating;       //audience text score
               Program.synopsis = movieInfo.movies[0].synopsis;                            //short synopsis if available  
               Program.cast1 = movieInfo.movies[0].abridged_cast[0].name;                  //first cast member
               Program.cast2 = movieInfo.movies[0].abridged_cast[1].name;                  //second cast member
               Program.cast3 = movieInfo.movies[0].abridged_cast[2].name;                  //third cast member
              
               
                }
            }
            
        }
    }

