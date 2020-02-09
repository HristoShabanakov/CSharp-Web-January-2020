using IRunes.Models;
using System.Linq;
using System.Net;

namespace IRunes.App.Extensions
{
    public static class EntityExtensions
    {
        private static string GetTracks(Album album)
        {
            return
                album.Tracks.Count == 0
                ? "There are currently no tracks in this album."
                : string.Join("" ,album.Tracks.Select((track, index) => track.ToHtmlAll(album.Id, index + 1)));
        }
        public static string ToHtmlAll(this Album album)
        {
            return $"<div><h3><a href=\"/Albums/Details?id={album.Id}\">{WebUtility.UrlDecode(album.Name)}</a><h3></div>";
        }
        public static string ToHtmlDetails(this Album album)
        {
            return "<div class=\"album-details d-flex justify-content-between row\">" +
                "   <div class=\"album-data col-md-5\">" +
                $"       <img src=\"{WebUtility.UrlDecode(album.Cover)}\" class=\"img-thumbnail\"/>" +
                $"       <h1 class=\"text-center\">Album Name: {WebUtility.UrlDecode(album.Name)}</h1>" +
                $"       <h1 class=\"text-center\">Album Price: {album.Price:F2}</h1>" +
                "       <div class=\"d-flex justify-content-between\">" +
                $"           <a class=\"btn bg-success text-white\" href=\"/Tracks/Create?albumId={album.Id}\">Create Track</a>" +
                "           <a class=\"btn bg-success text-white\" href=\"/Albums/All\">Back To All</a>" +
                "       </div>" +
                "   </div>" +
                "   <div class=\"albums-tracks col-md-6\">" +
                "       <h1>Tracks</h1>" +
                $"       {GetTracks(album)} " +
                "   </div>" +
                "</div>"
                ;
        }

        public static string ToHtmlAll(this Track track, string albumId, int index)
        {
            return $"<li><strong>{index}</strong>. <a href=\"/Tracks/Details?albumid={albumId}&trackid={track.Id}\"><i>{WebUtility.UrlDecode(track.Name)}</i></a></li>";
        }

        public static string ToHtmlDetails(this Track track)
        {
            return "<div class=\"track-details\">" +
            $"      <iframe src=\"{WebUtility.UrlDecode(track.Link)}\"></iframe>" +
            $"      <h1>Track Name: {WebUtility.UrlDecode(track.Name)}</h1>" +
            $"      <h1>Track Price: ${track.Price:F2}</h1>" +
            "</div>";
        }
    }
}
