namespace HDLand.Contracts
{
    public record GetMovieResponse(
        int Id,
        string Title,
        string Overview,
        string PosterPath,
        string ReleaseDate,
        string VoteAverage,
        string VoteCount);
}
