using AutoMapper;

namespace GrpcService.Services
{
    public interface IMovieDbService
    {
        MovieInfoReply GetMovieInfo(int id);
        MovieInfoReply GetMovieInfo(string name);
        IList<MovieInfoReply> GetMovieInfoList(Genre movieTypes);
    }

    public class MovieDbService : IMovieDbService
    {
        private readonly IMapper _mapper;
        private readonly IList<MovieDto> _movies;
        public MovieDbService(IMapper mapper)
        {
            _mapper = mapper;
            _movies = GetMovies();
        }

        public MovieInfoReply GetMovieInfo(int id)
        {
            return _mapper.Map<MovieInfoReply>(_movies.FirstOrDefault(movie => movie.Id == id));
        }
        public MovieInfoReply GetMovieInfo(string name)
        {
            return _mapper.Map<MovieInfoReply>(_movies.FirstOrDefault(movie => movie.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)));
        }

        public IList<MovieInfoReply> GetMovieInfoList(Genre movieTypes)
        {
            return _mapper.Map<IList<MovieInfoReply>>(_movies.Where(movie =>
                        movieTypes == Genre.All || movie.Genre == movieTypes));
        }

        private IList<MovieDto> GetMovies()
        {
            return new List<MovieDto>()
            {
                new MovieDto()
                {
                    Id = 0,
                    Name = "The Adventures of Robin Hood (1938)",
                    Genre = Genre.Action,
                    Description = "Arguably Flynn's greatest role, this is the classic, swashbuckling, adventure, costume epic/spectacle about the infamous rebel outlaw and his band of merry men from Sherwood Forest who \"robbed from the rich and gave to the poor.\" The charming Robin Hood (Flynn) fights for justice against the evil Sir Guy of Gisbourne (Rathbone), the villainous Sheriff of Nottingham (Cooper), and the scheming Prince John (Rains), while striving to win the hand of the beautiful Maid Marian (de Havilland) - and to save the English throne for King Richard (Hunter). This good-natured, extravagant adventure epic still packs romance, comedy, great sword play action, music, colorful characters and storybook fantasy. One of the earliest films to be shot in three-color Technicolor and, at the time, the most expensive film Warner Bros. had produced ($2 million). William Keighley started directing the film, but Curtiz finished the filming. Academy Award Nominations: 4, including Best Picture. Academy Awards: 3, including Best Interior Decoration, Best Original Score, Best Film Editing"
                },
                new MovieDto()
                {
                    Id = 1,
                    Name = "All Quiet On The Western Front (1930)",
                    Genre = Genre.Western,
                    Description = "Based on Erich Maria Remarque's timeless, pacifistic anti-war novel, this poetically brilliant epic about the horrors of war was hugely popular in its day. The moving drama, the first great sound anti-war film, follows a group of seven German schoolboys, with central character Paul (Ayres) inspired by their professor to fight for their country. They voluntarily enlist in World War I, believing in the glory of the Fatherland and learn about the realities of war from veteran soldier Katczinsky (Wolheim). The film documents their descent into war (and disillusionment) in graphic detail, from the everyday reality of trench warfare to starvation and butchery. The film tracks the boys in training, battle, and eventually their senseless, untimely deaths. Paul dies from an enemy bullet in the final scene as he reaches out to touch a butterfly. Shot on an epic scale with an impressive budget of $1.25 million, the film's realism and visual art created a sensation. Academy Award Nominations: 4, including Best Writing, Best Cinematography. Academy Awards: 2, including Best Production (Picture), Best Director."
                },
                new MovieDto()
                {
                    Id = 2,
                    Name = "Annie Hall (1977)",
                    Genre = Genre.Romance,
                    Description = "Bittersweet, cerebral, stream-of-consciousness, 70s, urban romantic comedy about a New York couple's neurotic love affair. Many consider this Allen's best work, and a transition from his earlier absurdist comedies to a richer, more thoughtful consideration of relationships. Innovatively filmed, with cartoon segments, flashbacks, monologues toward the camera, and other unique elements. Allen co-wrote, directed and stars as a kvetchy, neurotic, Brooklyn stand-up comedian Alvy Singer, wistfully recalling his bygone relationship with flighty, adorable, and irrepressibly Midwestern Annie Hall, an aspiring singer. (Film marks the fourth pairing of Keaton and Allen, who were also an off-screen couple at the time.) At first the cultural gap seems insurmountable, but despite their differences, they fall in love. As they get to know one another, they invariably attempt to change each other, causing friction and their eventual split. The film watches them try new relationships, as they reluctantly pull away from each other. The film, in actuality, chronicles the end of their relationship. Academy Award Nominations: 5, including Best Actor--Woody Allen. Academy Awards: 4, including Best Picture, Best Director, Best Actress--Diane Keaton, Best Original Screenplay."
                },
                new MovieDto()
                {
                    Id = 3,
                    Name = "Apocalypse Now (1979)",
                    Genre = Genre.Action,
                    Description = "A masterful, thought-provoking, pretentious film, with beautifully-chaotic visuals, about the nightmarish, moral madness of the Vietnam War, inspired by the novella Heart of Darkness by Joseph Conrad. Considered by many to be the best war movie of all time, with incredible performances, especially that of hawkish Lt. Colonel Kilgore (Duvall) who \"loves the smell of napalm in the morning.\" Sweeping, surreal, still-controversial Vietnam war epic. An Army captain (Sheen) is sent into the Cambodian jungle aboard a patrol boat carrying a young, spaced-out crew. Their mission: to assassinate (\"terminate\") a Buddha-like Colonel Kurtz (Brando) who has become an insane demi-god and now runs his own fiefdom. The grueling production in the Philippines led to vast budget overruns and physical and emotional breakdowns. Academy Award Nominations: 8, including Best Picture, Best Director, Best Adapted Screenplay, Best Supporting Actor--Robert Duvall, Best Film Editing. Academy Awards: 2, including Best Cinematography, Best Sound."
                },
                new MovieDto()
                {
                    Id = 4,
                    Name = "The Best Years of Our Lives (1946)",
                    Genre = Genre.Drama,
                    Description = "William Wyler's landmark, classic drama, and Best Picture-winning film was both powerful and provocative, with many touching moments in the lives of combat survivors now returned to their former lives, with both hopefulness and poignancy - attempting readjustment to peacetime life and discovering that they had fallen behind. The lengthy film featured great acting, story-telling, direction and pacing by Wyler. It was based upon the 1945 novella \"Glory for Me\" by MacKinlay Kantor. It was perhaps the most memorable film about the aftermath of World War II, unfolding with a number of great plot threads about the homecoming of three servicemen to their small town. The compassionate movie portrayed the reality of altered lives, readjustments at work, dislocated marriages and the inability to communicate the experience of war on the front lines or the home front. This was the first picture for Harold Russell, a non-actor and war veteran who was an actual amputee, who won two Oscars for the same role (a unique achievement) - Best Supporting Actor, and a Special Honorary Oscar \"For bringing hope and courage to his fellow veterans through his appearance...\" In the film's opening set in the nose of a B-17 bomber, three returning veterans had their first glimpse of their (fictional) hometown of Boone City - feeling alienated, aloof and detached from the strange sights and memories of their former home - and attempting readjustment to peacetime life and discovering that they had fallen behind. The three WWII veterans were: middle-class husband Army Sergeant Al Stephenson (Fredric March), a former Cornbelt Bank banker who turned to drinking, decorated Air Force Captain Fred Derry (Dana Andrews) who was rejected by his unfaithful war-bride spouse Marie Derry (Virginia Mayo) and was forced to return to his old job as a soda-jerk, and handicapped seaman Homer Parrish (Oscar-winning Harold Russell) who had lost both arms and agonized over his relationship with his childhood sweetheart-girlfriend Wilma Cameron (Cathy O'Donnell). In the film's most poignant moment, Homer's mother (Minna Gombell) experienced her first look at her double-amputee son's hooks for hands, and had an uncontrollable reaction. During his deeply-moving homecoming reunion scene, Sgt. Al Stephenson entered his apartment complex and then the door of his apartment and silenced with his cupped hand the mouths of his son Rob (Michael Hall) and daughter Peggy (Teresa Wright) - and then suddenly, his wife Milly (Myrna Loy) was surprised to realize that he had come through the door. Fred experienced PTSD - fitful, sweaty nightmares of a disastrous bombing run over Germany, while Peggy (a trained nurse) comforted and soothed him. Persistent and young Peggy Stephenson, Al's intelligent, articulate, headstrong daughter, made some remarkable homewrecking efforts to win Fred away from his mismatched marriage to his unloving blonde floozy wife Marie Derry. Another of the most remarkable scenes was of Fred's walk through a junked airplane graveyard where he relived his many wartime memories of bombing missions in the nose of an abandoned B-17 bomber. The film concluded with Homer's wedding to Wilma, when he demonstrated great skill in placing a ring on her finger - with the added knowledge that Peggy and Fred - seen in the background - would eventually also marry after his divorce with Marie could be finalized. Academy Award Nominations: 8, including Best Sound Recording. Academy Awards: 7, including Best Picture, Best Actor--Fredric March, Best Supporting Actor--Harold Russell, Best Director, Best Screenplay. A Special Academy Award for Russell for bringing hope and courage to his fellow veterans through his appearance in the film."
                },
                new MovieDto()
                {
                    Id = 5,
                    Name = "Blade Runner (1982)",
                    Genre = Genre.ScienceFiction,
                    Description = "Moody futuristic, sci-fi noirish thriller, with stunning, visually-dazzling effects and a brooding atmosphere, about a hard-boiled detective hunting near-human \"replicants.\" Based on the novel Do Androids Dream of Electric Sheep? by Philip K. Dick. In a totalitarian, decaying 21st century Los Angeles (2019), a jaded, semi-retired, Philip Marlowe-style ex-cop (Ford), known as a \"blade runner,\" is forced out of retirement to hunt down and eliminate four \"replicants\" (Hannah, Hauer, Cassidy) - genetically engineered super-humanoid robots. On earth illegally from an Off-world colony where they were used as slave laborers, and with a built-in, shortened life span of only four years, the androids have mutinied and escaped in order to confront the individual who designed them (Turkel). Seeing their heroic struggle against an inhuman system, the blade-runner ultimately falls in love with an android femme fatale (Young). Academy Award Nominations: 2, including Best Art Direction-Set Direction, Best Visual Effects."
                },
                new MovieDto()
                {
                    Id = 6,
                    Name = "Bride of Frankenstein (1935)",
                    Genre = Genre.Comedy,
                    Description = "Darkly witty, black comedy, semi-humorous sequel to the classic Frankenstein film (and precursor to The House Of Frankenstein in 1944) about a mad scientist building a mate in his laboratory for his monster. Having escaped the fiery castle that engulfed him at the end of the 1931 horror classic Frankenstein, the Frankenstein monster (Karloff) is back - now more civilized and human - and talking with a small vocabulary after being taught by a blind hermit. Baron Henry Frankenstein (Clive), the monster's tormented creator, is drawn back to his experiments by effeminate, sardonic Dr. Pretorious (Ernest Thesiger). The demented Henry is convinced that the Monster really needs a female mate (Lanchester) - the over-the-top Bride hisses at the Monster during their first meeting. Academy Award Nominations: 1, Best Sound Recording."
                },
                new MovieDto()
                {
                    Id = 7,
                    Name = "Casablanca (1942)",
                    Genre = Genre.Romance,
                    Description = "Perennially at the top of every all-time greats list, and indisputably one of the landmarks of the American cinema, although an accidental Hollywood masterpiece. Critically-acclaimed, bittersweet, popular, much-loved, WWII-flavored, nostalgic story of intrigue and love that teamed Bogart and Bergman as ill-fated lovers. A laconic, cynical idealist, American expatriate and war profiteer Rick Blaine (Bogart) in Nazi-occupied WW II Morocco is content to be cafe owner for his Cafe Americain until a past love, in the luminous form of Ilsa Lund (Bergman) who mysteriously left him in Paris, returns to his life and inspires him to stand up for the French Resistance with her husband Victor Laszlo (Henreid). In the final scene in the fog at the airport, he dutifully and nobly sacrifices his love for her - \"We'll always have Paris.\" Academy Award Nominations: 8, including Best Actor--Humphrey Bogart, Best Supporting Actor--Claude Rains, Best B/W Cinematography. Academy Awards: 3, including Best Picture, Best Director, Best Screenplay."
                },
                new MovieDto()
                {
                    Id = 8,
                    Name = "Psycho (1960)",
                    Genre = Genre.Horror,
                    Description = "The greatest, most influential Hitchcock horror/thriller ever made and the progenitor of the modern Hollywood horror film, based on Robert Bloch's novel. A classic, low budget, manipulative, black and white tale that includes the most celebrated shower sequence ever made. Worried about marital prospects after a lunch tryst with her divorced lover (Gavin), blonde real estate office secretary Marion Crane (Leigh) embezzles $40,000 and flees, stopping at the secluded off-road Bates Motel, managed by a nervous, amateur taxidermist son named Norman (Perkins). The psychotic, disturbed \"mother's boy\" is dominated by his jealous 'mother', rumored to be in the Gothic house on the hillside behind the dilapidated, remote motel. The story includes the untimely, violent murder of the main protagonist early in the film, a cross-dressing transvestite murderer, insanity, a stuffed corpse, and Oedipal Freudian motivations. Academy Award Nominations: 4, including Best Supporting Actress--Janet Leigh, Best Director, Best B/W Cinematography"
                },
                new MovieDto()
                {
                    Id = 9,
                    Name = "King Kong (1933)",
                    Genre = Genre.Thriller,
                    Description = "Classic horror-fantasy thriller, with ground-breaking technical effects (stop-motion animation), a beauty-and-the-beast drama about a misunderstood, gigantic ape running wild in NYC - one of the masterpieces of cinema. Fortune-hunters, including filmmaker Denham (Armstrong) and his crew and a lovely, nubile starlet (Wray) travel to remote, fog-shrouded Skull Island to shoot a jungle movie. In search of the fabled giant ape, the magnificent, exotic, and dangerous \"King Kong,\" they stumble upon a prehistoric world populated by dinosaurs and giant snakes. Enticing the fifty-foot gorilla with the lovely blonde - that the natives have kidnapped and offered as a gift to the beast, they eventually subdue and capture the monstrous creature with gas bombs. Denham brings him back to New York City as a sideshow attraction. The beast breaks his 'civilized' chains, escapes and goes on a rampage, ransacking the city in search of the young actress. The film climaxes with the hairy beast clinging to the top of the Empire State Building as pilots shoot him down. \"It was Beauty killed the Beast.\" No Academy Award nominations."
                },
                new MovieDto()
                {
                    Id = 10,
                    Name = "Jaws (1975)",
                    Genre = Genre.Horror,
                    Description = "From the best-selling novel by Peter Benchley and with a thrilling, memorable and rousing score by John Williams. A Great White Shark terrorizes a popular Massachusetts resort, Amity Island, during the summer tourist season in this action/adventure/horror classic, an early blockbuster film from Steven Spielberg. Surprise attacks on the New England coast, in which the monstrous man-eater preys on the inhabitants and vacationers alike, are truly frightening and scary. Three unlikely partners team up on a suspenseful 'fishing trip' to hunt down the rogue and destroy it: the new chief of police from New York (Scheider), a young university-educated oceanographer (Dreyfuss), and a crusty, grizzled old-time fisherman (Shaw) resembling the obsessed Ahab in the Moby Dick tale. Academy Award Nominations: 4, including Best Picture. Academy Awards: 3, including Best Sound, Best Original Score, Best Film Editing."
                },
                new MovieDto()
                {
                    Id = 11,
                    Name = "Taxi Driver (1976)",
                    Genre = Genre.Action,
                    Description = "One of Martin Scorsese's greatest films, about a violent, alienated, unfocused, psychotic NYC taxi driver fatalistically disturbed by the squalid, hellish urban underbelly of pimps, whores, winos, and junkies. Ex-Marine Travis Bickle (De Niro) works the night shift through Times Square in his cab, encountering nightmarish Gothic horrors, moral decay and lowlifes. Off hours during the day, he kills time by frequenting sleazy porno houses and eating junk food. His one feeble attempt at social and emotional contact - a date with a blonde political campaign worker Betsy (Shepherd) fails miserably when he takes her to a porn film. His fantasized one-man campaign/mission to clean up the streets focuses on saving a prepubescent child prostitute Iris (Foster). It ends with a failed political assassination attempt, and a rage-filled, pent-up blood-bath massacre, including the killing of Iris' pimp \"Sport\" (Harvey Keitel). In the aftermath, the repellent character emerges as a vindicated, folk savior-hero. Academy Award Nominations: 4, including Best Picture, Best Actor--Robert De Niro, Best Supporting Actress--Jodie Foster, Best Original Score (Bernard Herrmann)."
                },
            };
        }

        public class MovieDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Genre Genre { get; set; }
        }
    }
}