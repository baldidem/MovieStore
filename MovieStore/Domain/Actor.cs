﻿namespace MovieStore.Domain
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<MovieActor> MovieActors { get; set; }
    }
}
