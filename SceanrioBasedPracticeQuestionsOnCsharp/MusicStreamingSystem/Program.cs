// Question 12: Music Streaming Service
// Scenario: A music platform needs to manage songs, playlists, and user preferences.
// Requirements:
// csharp
// // In class Song:
// // - string SongId
// // - string Title
// // - string Artist
// // - string Genre
// // - string Album
// // - TimeSpan Duration
// // - int PlayCount

// // In class Playlist:
// // - string PlaylistId
// // - string Name
// // - string CreatedBy
// // - List<Song> Songs

// // In class User:
// // - string UserId
// // - string UserName
// // - List<string> FavoriteGenres
// // - List<Playlist> UserPlaylists

// // In class MusicManager:
// public void AddSong(string title, string artist, string genre, 
//                    string album, TimeSpan duration)
// public void CreatePlaylist(string userId, string playlistName)
// public bool AddSongToPlaylist(string playlistId, string songId)
// public Dictionary<string, List<Song>> GroupSongsByGenre()
// public List<Song> GetTopPlayedSongs(int count)
// Use Cases:
// •	Add songs with metadata
// •	Create and manage playlists
// •	Group songs by genre
// •	Track song popularity
// •	User profile management

class Song
{
    public string? SongId{get; set;}
    public string? Title{get; set;}
    public string? Artist{get; set;}
    public string? Genre{get; set;}
    public string? Album{get; set;}
    public TimeSpan Duration{get; set;}
    public int PlayCount{get; set;}
    public Song(){}
}
public class Playlist
{
    public string? PlaylistId{get; set;}
    public string? Name{get; set;}
    public string? CreatedBy{get; set;}
    public List<Song> Songs{get; set;}
    public Playlist()
    {
        Songs = new List<Song>();
    }
}
public class User
{
    public string UserId{get; set;}
    public string UserName{get; set;}
    public List<string> FavoriteGenres{get; set;}
    public List<Playlist> UserPlaylists{get; set;}
    public User()
    {
        FavoriteGenres = new List<string>();
        UserPlaylists = new List<Playlist>();
    }
}
public class MusicManager
{
    public static Dictionary<string, Song> songDetails = new Dictionary<string, Song>();
    public static Dictionary<string, Playlist> playlistDetails = new Dictionary<string, Playlist>();
    public static int songCounter = 1;
    public static int playlistCounter = 1;

    public void AddSong(string title, string artist, string genre, string album, TimeSpan duration)
    {
        Song song = new Song()
        {
            SongId = songCounter.ToString("D3"),
            Artist = artist,
            Title = title,
            Genre = genre,
            Album = album,
            Duration = duration,
            PlayCount = 0
        };

        songDetails.Add(song.SongId, song);
        songCounter++;
    }

    public void CreatePlaylist(string userId, string playlistName)
    {
        Playlist playlist = new Playlist()
        {
            PlaylistId = playlistCounter.ToString("D3"),
            Name = playlistName,
            CreatedBy = userId
        };

        playlistDetails.Add(playlist.PlaylistId, playlist);
        playlistCounter++;
    }

    public bool AddSongToPlaylist(string playlistId, string songId)
    {
        if (!playlistDetails.ContainsKey(playlistId) || !songDetails.ContainsKey(songId))
        {
            Console.WriteLine("Playlist or Song not found");
            return false;
        }

        Playlist playlist = playlistDetails[playlistId];
        Song song = songDetails[songId];

        playlist.Songs.Add(song);
        song.PlayCount++; 

        return true;
    }

    public Dictionary<string, List<Song>> GroupSongsByGenre()
    {
        Dictionary<string, List<Song>> result = new Dictionary<string, List<Song>>();

        foreach (var item in songDetails)
        {
            Song song = item.Value;
            string genre = song.Genre;

            if (!result.ContainsKey(genre))
            {
                result[genre] = new List<Song>();
            }

            result[genre].Add(song);
        }

        return result;
    }

    public List<Song> GetTopPlayedSongs(int count)
    {
        return songDetails.Values.OrderByDescending(s => s.PlayCount).Take(Count).ToList();
    }
}
