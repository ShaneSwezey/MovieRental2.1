namespace MovieData.DataModels
{
    // Model for Many to many table MovieActor
    // Conntects table Movies to table Actors
    public class MovieActor
    {
        // MovieId reference key in table Movie
        public int MovieId { get; set; }
        // Entity reference
        public Movie Movie { get; set; }
        // ActorId reference key in table Actor
        public int ActorId { get; set; }
        // Entity reference
        public Actor Actor { get; set; }

    }
}
