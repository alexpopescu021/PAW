﻿using Microsoft.EntityFrameworkCore;
using PAW.DataAcess;
using PAW.Model;
using PAWDataAcess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAWDataAcess.Repos
{
    public class EFSongRepository : EFBaseRepository<Song>, ISongRepository
    {
        public EFSongRepository(PAWDbContext dbContext) : base(dbContext)
        { }

        public IEnumerable<Song> FindByName(string nameToFind)
        {
            var songsList = dbContext.Songs
                                .Where(song =>
                                            song.Title
                                            .ToLower()
                                            .Contains(nameToFind.ToLower()));

            return songsList.AsEnumerable();
        }

        public new Song GetById(Guid songId)
        {
            var Song = dbContext.Songs.Where(song => song.Id == songId).FirstOrDefault();
            return Song;
        }

        public new IEnumerable<Song> GetAll()
        {
            return dbContext.Songs.AsEnumerable();
        }

        public bool RemoveSong(Guid songId)
        {
            var entityToRemove = GetById(songId);

            if (entityToRemove != null)
            {
                dbContext.Remove(entityToRemove);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

       
    }
}