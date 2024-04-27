
using Labb3.Data;
using Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext <Labb3DbContext> (options =>
            options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Return all persons
            app.MapGet("/persons", async (Labb3DbContext context) =>
            {
                var persons = await context.Persons.ToListAsync();
                if (persons == null || !persons.Any())
                {
                    return Results.NotFound("Hittar inga personer");
                }
                return Results.Ok(persons);
            });

            // Return interests for a specific person
            app.MapGet("/persons/{personId}/interests", async (int personId, Labb3DbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);
                if (person == null)
                {
                    return Results.NotFound("Hittar ingen person med detta ID.");
                }

                var interests = await context.InterestLists
                    .Where(x => x.FK_PersonId == personId)
                    .Select(x => x.Interest)
                    .ToListAsync();

                if (interests == null || !interests.Any())
                {
                    return Results.NotFound("Hittar inga intressen för denna person.");
                }
                return Results.Ok(interests);
            });

            // Return links for a specific person
            app.MapGet("/persons/{personId}/links", async (int personId, Labb3DbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);

                if (person == null)
                {
                    return Results.NotFound("Hittar ingen person med detta ID.");
                }

                var links = await context.InterestLists
                    .Where(x => x.FK_PersonId == personId && x.Link != null)
                    .Select(x => x.Link)
                    .ToListAsync();

                if (links == null || !links.Any())
                {
                    return Results.NotFound("Hittar inga länkar för denna person.");
                }

                return Results.Ok(links);
            });

            // Add new interest for a specific person
            app.MapPost("/persons/{personId}/interests", async (int personId, Interest newInterest, Labb3DbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);
                if (person == null)
                {
                    return Results.NotFound("Hittar ingen person med detta ID.");
                }

                var existingInterest = await context.Interests
                    .FirstOrDefaultAsync(i => i.InterestName == newInterest.InterestName);

                if (existingInterest == null)
                {
                    existingInterest = new Interest
                    {
                        InterestName = newInterest.InterestName,
                        InterestDescription = newInterest.InterestDescription
                    };
                    context.Interests.Add(existingInterest);
                    await context.SaveChangesAsync();
                }

                var newPersonInterest = new InterestList
                {
                    FK_PersonId = personId,
                    FK_InterestId = existingInterest.InterestId
                };
                context.InterestLists.Add(newPersonInterest);
                await context.SaveChangesAsync();

                return Results.Created($"/persons/{personId}/interests", existingInterest);
            });

            // Add new link to a person and interest
            app.MapPost("/persons/{personId}/interests/{interestId}/links", async (int personId, int interestId, Link newLink, Labb3DbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);
                if (person == null)
                {
                    return Results.NotFound("Hittar ingen person med detta ID.");
                }

                var interest = await context.Interests.FindAsync(interestId);
                if (interest == null)
                {
                    return Results.NotFound("Hittar inga intressen för denna person.");
                }

                var link = new Link
                {
                    LinkUrl = newLink.LinkUrl,
                    LinkName = newLink.LinkName
                };

                context.Links.Add(link);
                await context.SaveChangesAsync();

                var newPersonInterestLink = new InterestList
                {
                    FK_PersonId = personId,
                    FK_InterestId = interestId,
                    FK_LinkId = link.LinkId
                };

                context.InterestLists.Add(newPersonInterestLink);
                await context.SaveChangesAsync();

                return Results.Created($"/persons/{personId}/interests/{interestId}/links", newPersonInterestLink);
            });

            app.Run();
        }
    }
}
