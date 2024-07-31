
using library.Data;
using library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace library.Service
{
    public class SeedService : ISeedService
    {
        LibraryModel library = new()
        {
            GenreName = "chasidut",
            Shelves = [
                       new ()
                        {
                            Height = 100,
                            Width = 100,
                            Sets = [
                                new ()
                                {
                                    SetName = "chatt",
                                    Books = [
                                        new () {

                                            BookName = "chumash",
                                            Height = 20,
                                            Width = 20,
                                            GenreName = "chasidut"

                                        },
                                        new () {

                                            BookName = "tehilim",
                                            Height = 20,
                                            Width = 20,
                                            GenreName = "chasidut"

                                        },
                                        new () {

                                            BookName = "tania",
                                            Height = 20,
                                            Width = 20,
                                            GenreName = "chasidut"

                                        },
                                        new () {

                                            BookName = "sidur",
                                            Height = 20,
                                            Width = 20,
                                            GenreName = "chasidut"

                                        }

                                        ]

                                }
                                ]
                        }
                       ]
        };


        private readonly ApplicationDBContext _dbContext;

        public SeedService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;  
        }

        public async Task<bool> Seed()
        {
            if (_dbContext.library.IsNullOrEmpty())
            {
                
                await _dbContext.library.AddAsync(library);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                   return false;
                
            }
        }
    }
}




