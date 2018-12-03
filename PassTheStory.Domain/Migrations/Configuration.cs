namespace PassTheStory.Domain.Migrations
{
    using PassTheStory.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoryContext context)
        {
            context.Stories.AddOrUpdate(x => x.StoryId,
                new Story { StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91"), StoryName = "The True Meaning of Christmas", IsFinished = true, NextAuthor = "WineDarkSailor" },
                new Story { StoryId = new Guid("b6484081-d785-4a54-80f3-2a37f02443af"), StoryName = "Silence is Golden", IsFinished = false, NextAuthor = "TheSonAlsoWrites" },
                new Story { StoryId = new Guid("c6910b8e-8a22-4a81-9fa3-6b3c152719a1"), StoryName = "The Redemption of Adolf Hitler", IsFinished = false, NextAuthor = "MobyRichard" },
                new Story { StoryId = new Guid("9350c0c1-9291-4a58-8f34-e6ff16fd4b16"), StoryName = "A New Dawn for Magick", IsFinished = false, NextAuthor = "TheSonAlsoWrites"},
                new Story { StoryId = new Guid("b8cfa03c-ce0a-46dd-9b19-fdff4f0b2159"), StoryName = "A Voice from the Past", IsFinished = false, NextAuthor = "TheScarletWriter" },
                new Story { StoryId = new Guid("43f854d8-11c2-4a44-b78b-b71163f8fa45"), StoryName = "King of the Bees", IsFinished = true, NextAuthor = "TheScarletWriter" },
                new Story { StoryId = new Guid("6a6ce39c-bd3e-4508-b6f2-ff459d0d80ac"), StoryName = "The Devil You Know", IsFinished = false, NextAuthor = "WineDarkSailor" },
                new Story { StoryId = new Guid("39a0236b-8ad7-4242-baf4-671209f0a23d"), StoryName = "The Path Not Taken", IsFinished = true, NextAuthor = "PrideAndUnprejudiced" },
                new Story { StoryId = new Guid("e46aaa5c-6fdf-4d6f-bd74-e6ec24b2ed3a"), StoryName = "The Gospel According to Chad", IsFinished = false, NextAuthor = "TheSonAlsoWrites" },
                new Story { StoryId = new Guid("4d5eb60b-ef05-4785-95cf-c99b12550a77"), StoryName = "The Long Goodbye", IsFinished = false, NextAuthor = "TheGreaterGatsby" },
                new Story { StoryId = new Guid("d2ceb713-a3ba-403d-b5ed-b1b3d089e3b6"), StoryName = "The Experiment", IsFinished = false, NextAuthor = "PrideAndUnprejudiced" });

            context.StoryParts.AddOrUpdate(x => x.PartId,
                new StoryPart{ PartId = new Guid("361a358c-d8b8-493f-8ade-848a6b69f863"), CreatedDateTime = DateTime.Parse("11/26/2018 12:25 PM"), PartNumber = 1, 
                    PartText = "The lone survivor of an Arctic exploration, you were captured generations ago by a band of tiny warriors. They’ve placed you under an enchantment to do their bidding; heading out into the world once each year as their unwilling emissary. They call you “slave,” or in their tongue, “Santa.”", 
                    Author = "MobyRichard", IsEnd = false, StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91")},
                new StoryPart{ PartId = new Guid("7e95948b-df5d-48c6-b27d-8f1483ff043e"), CreatedDateTime = DateTime.Parse("11/26/2018 6:48 PM"), PartNumber = 2, 
                    PartText = "The Fae - the elfkin - have coveted our world for eons. Stories sneak through into human consciousness of their acts. The British had King Arthur, the seelie and unseelie. Australia has the mysterious Baijini - the white people from the North. Japan has the Kami. The Mayans had terrible twins and boys with antlers.\n\n" +
                    "These are folk memories of wars that pushed us to the edge of extinction writ large in the tapestry of human existence, permeating every culture and consciousness.\n\n" +
                    "We were trapped in pack ice, the ship's hull cracking as great forces moved, when they came. The expedition had been to find the North West Passage, and the captain had insisted that, with stars and providence - and one of Master Harrison's clocks - we would be the first to chart the route to the riches of the East.", 
                    Author = "TheGreaterGatsby", IsEnd = false, StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91")},
                new StoryPart{ PartId = new Guid("c5edcb82-77a0-44e0-acc6-042f129f7d16"), CreatedDateTime = DateTime.Parse("11/27/2018 8:14 AM"), PartNumber = 3, 
                    PartText = "We all knew the risks; Hudson had not only failed, but failed and died. Nor had Cook succeeded. Yet we, in a fit of youthful folly and hope believed that the passage would be found. When the ship stopped and broke herself in the ice we furrowed brows knitted with ice. When the food and water ran low we looked at each other with wary eyes. And when the rum ration finished, the mutiny began.\n\n" +
                    "Nights in the north come long or quick depending on season; the bloody night seemed to last forever. The loyalists in the f'castle, the mutineers scurrying like rats across deck and rope to finish us off with shot or cutlass. Sixteen turned to six, turned to three and, as Midshipman Smollett choked his last, wheezing gasp, one. My shirt was coated with his blood, turned deep sanguine by his gizzards so that only a few cuffs and collars of white remained.", 
                    Author = "WineDarkSailor", IsEnd = false, StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91")},
                new StoryPart{ PartId = new Guid("6d335b1e-a662-4e2d-a513-44bec165340d"), CreatedDateTime = DateTime.Parse("11/27/2018 4:52 PM"), PartNumber = 4, 
                    PartText = "By then dawn finally broke - not a true dawn, just an orange, permeating glow for we were too far North for the sun to rise - and I decided to accept my fate. I opened the barricades, walked past the splintered windows pock-marked from where leaden balls had flown, and decided to face the mutinous rabble.\n\n" +
                    "Only they weren't there. All that remained on the deck was silence and death.\n\n" +
                    "And a small figure, ears pointed like a pinecone, features cruel and barbarous. Quietly he looked at me, and I realised with horror he was gnawing on the bony hand - severed clean - of Samuel Saunders, one of the topmen, whose tattoos and curling hair I would have known anywhere. My revulsion must have been plain, for he dropped the limb onto the deck, and licked his vile lips with slow precision, a stream of gore giving sheen to his teeth.\n\n" +
                    "\"How now, traveler?\" he asked. \"Methinks we have found a Santa Claus.\"", 
                    Author = "PrideAndUnprejudiced", IsEnd = false, StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91")},
                new StoryPart{ PartId = new Guid("d7f2e8cb-c54d-4475-b81d-24475a6e5e9c"), CreatedDateTime = DateTime.Parse("11/28/2018 11:05 AM"), PartNumber = 5, 
                    PartText = "It did not take long for them to imprison me. I was in no state, weary as I felt the world and drunk from battle, to resist the seven or eight of them that quickly surrounded me. And yet, unlike the rest of the crew - who they had slaughtered to a man, I would later discover, the scent of blood from the mutiny drawing them as a lance draws the pus - they chose for me to live. I remember a sleigh sprinting atop snow with graceful ease, and a burning net cast over my body. I do not recall much more, for it was long ago and the bleakness of my predicament has blotted the inky stains of memory.\n\n" +
                    "I do remember the workshop, though, and the warm fire that removed some of the freeze from my flesh, and the feast of flesh they provided that made me gag and choke. It was not my crew, they pledged, though to this day I do not know if such is true; all I know is that they were committed to fattening me up, turning wasted muscle and gaunt cheeks into ruddy merriment.", 
                    Author = "MobyRichard", IsEnd = false, StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91")},
                new StoryPart{ PartId = new Guid("d4a686d1-c685-431e-812b-d7469e603118"), CreatedDateTime = DateTime.Parse("11/28/2018 8:36 PM"), PartNumber = 6, 
                    PartText = "I do not know how long time passed. For I, it felt like an afternoon, and, truth be told, a pleasant one in which I drank and laughed with them, my captors and saviours in equal measure. My questions on their origins were rebuffed, and their countenance assured me that they were on the side of right - that they had dealt with the mutineers only. Though, of course, today I know the truth of it. And it would be a lie if I said I did not suspect it at the time. Then the leader, a wizened crone hunched over so that her tiny frame twisted her head almost to her knees, spoke in creaking tongue, bidding me to sit with her by the fire.\n\n" +
                    "\"We have a proposition for ye, Santa. Though it would vex us for you to say no, and we are not kin to be vexed.\"\n\n" +
                    "\"And what is that?\" I asked. \"And why do you call me San...\"\n\n" +
                    "\"Santa. Servant. Claus. Of the kinfolk. That is you, and that is what you shall be the rest of your days.\"", 
                    Author = "TheScarletWriter", IsEnd = false, StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91")},
                new StoryPart{ PartId = new Guid("238bc577-f943-4117-b619-c3bc337c2166"), CreatedDateTime = DateTime.Parse("11/29/2018 10:57 AM"), PartNumber = 7, 
                    PartText = "\"But I must return to England.\"\n\n" +
                    "\"Oh!\" she clapped her hands at that. \"And ye shall, Santa Claus! Ye shall! For already they lay the lines of iron that bind my kin, twisted 'railways' that we cannot abide. Your folk shall call it science and progress, oblivious to the truth of it! For they are laying a maze that we cannot navigate! A prison on ancient lines that will forever banish us from their lands. In the past, we quarreled with your folk. Since your folk came into being, we have tried to speak with you, words of warmth and diplomacy. Yet you have taken our aid as malice and our gifts as cruelty unbound. Truly, we wish to put this aside. We have been pushed to the fringes of your world; to the edge of myth itself. Our last refuge are the cold lands of the North, and we need an emissary to bridge our worlds. That, Santa, shall be you.\"", 
                    Author = "TheSonAlsoWrites", IsEnd = false, StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91")},
                new StoryPart{ PartId = new Guid("fe597b76-a793-4434-9417-40362456e26d"), CreatedDateTime = DateTime.Parse("11/29/2018 3:29 PM"), PartNumber = 8, 
                    PartText = "\"What do you mean?\" I confess, I had too many questions that I did no realise her lies. Diplomacy? Parlour tricks designed to vex and beguile. And Gifts? Only those as deadly as they could muster. Though not as deadly as the one I write to warn you of.\n\n" +
                    "\"I mean,\" the crone said, \"that once a year, for as many years as it takes, you shall deliver our presents into the world. And, through our presents, we shall bond ourselves in union with your kind.\"\n\n" +
                    "The only bonds she truly meant were that of a slave. For their scheme was far darker than I could imagine. And even the blood of ancient Samhain will pallor compared with the carnage coming this eve, when they unleash their true \"gift\" upon you all.", 
                    Author = "WineDarkSailor", IsEnd = true, StoryId = new Guid("6709351d-fe86-45de-b9c8-755f1224ca91")},

                new StoryPart{ PartId = new Guid("65dfac75-d54c-49a4-aa8e-296a0d9505ac"), CreatedDateTime = DateTime.Parse("12/01/2018 1:20 PM"), PartNumber = 1, 
                    PartText = "Humanity has been emitting signals into space for a long time in hopes of extra terrestrial contact. The scientists finally received a message, which read: “Be quiet or they will find you.”", 
                    Author = "TheScarletWriter", IsEnd = false, StoryId = new Guid("b6484081-d785-4a54-80f3-2a37f02443af")},
                new StoryPart{ PartId = new Guid("f7c088a3-7754-4418-b189-8bbc1b5f0bc0"), CreatedDateTime = DateTime.Parse("12/01/2018 9:46 PM"), PartNumber = 2, 
                    PartText = "It was the perfect trap. Humanity had been searching so desperately for so long, that it wasn't even a decision to kill outgoing broadcasts when we got the message. The second we received it and played it back through hushed excitement, the call went out.\n\n" +
                    "The message couldn't have been more clear. \"Be quiet, or they will find you.\" Then and there we killed all outbound signals. The word spread like nothing I had ever seen, and one by one, every center around the country went dark. After us, each country around the world followed suit. But it didn't stop there. We were terrified of what we were dealing with, and extraterrestrial broadcasts became the least of our concerns. We killed radio around the world. We killed satellite feeds. We even told the public to avoid using wifi. How quiet did we have to be? There was no way to tell. But we were scared, and we were right to be scared.", 
                    Author = "TheGreaterGatsby", IsEnd = false, StoryId = new Guid("b6484081-d785-4a54-80f3-2a37f02443af")},
                new StoryPart{ PartId = new Guid("5f36bd97-cdb5-4a02-831e-80b4afcdfb62"), CreatedDateTime = DateTime.Parse("12/02/2018 8:36 AM"), PartNumber = 3, 
                    PartText = "Every form of communication with a broadcast range greater than 1,000 feet had to come down. Everything that wasn't held together with hard wires had to go. And pulling it off was no small feat -- governments around the world had to coordinate the herculean undertaking of regressing our communications grid. But through all the chaos and the fear, we did it. No undertaking is too massive when humanity itself is fearing for extinction. When all was said and done, we had presidents shaking hands with honorable chairmen, and strangely, there was a kind of lingering unity. A sense that we had come together to save ourselves, and a feeling that at the end of the day, we really could put aside our quarrels to get things done. I don't think I've ever heard so many people say \"we're gonna be okay\" than I did on the day the transition was deemed complete. People even started talking about all the other things we'd be able to accomplish, now that we were playing nice.", 
                    Author = "PrideAndUnprejudiced", IsEnd = false, StoryId = new Guid("b6484081-d785-4a54-80f3-2a37f02443af")},
                new StoryPart{ PartId = new Guid("fec6fbff-9675-4b61-a4db-c3ad269f42f2"), CreatedDateTime = DateTime.Parse("12/02/2018 2:18 PM"), PartNumber = 4, 
                    PartText = "In a cosmic blink of an eye, we went from speaking loudly, to listening carefully. Whoever sent that message must have been able to tell we had gone dark, right? Maybe they'd take our silence as some form of positive acknowledgment. Get back in touch. Explain things clearly. Every piece of white noise was carefully sent to every analyst that we could get our hands on, but we weren't getting any more messages. And really, that's not so strange, when you think about it. Whoever sent that message must have gone to great risk sending it to us. Whatever was lurking out there, listening, might have caught their message. Maybe they were already gone.\n\nOr maybe it was an ancient message. Sent from some long-forgotten civilization a million million light-years away, and we just happened to overhear. Maybe we were taking the whole thing out of context. Maybe it was a false alarm.", 
                    Author = "MobyRichard", IsEnd = false, StoryId = new Guid("b6484081-d785-4a54-80f3-2a37f02443af")},
                new StoryPart{ PartId = new Guid("4ab7d3c3-3529-41e8-bd25-3761114ca24b"), CreatedDateTime = DateTime.Parse("12/02/2018 11:10 PM"), PartNumber = 5, 
                    PartText = "One thing was for certain, though: we weren't about to tempt fate by sending anything for a long time. Maybe ever. Some folks even talked about drawing up broadcast laws to make sure nothing bled out into space. Didn't want some long-range radio enthusiast ruining it for the rest of us.\n\n" +
                    "But, uh, as it turns out... in a busy galaxy, it was easier for them to find silence than it was to find noise. Noise was everywhere, but silence was golden. There was no warning message this time, you understand. No ominous command. They just... arrived.\n\n" +
                    "Not two weeks after broadcasts went down, we detected the first object entering the solar system from the far end, all the way out near Pluto. Less than two days later, it was approaching Mars. As the first object arrived, two more were detected. After those two arrived, there was another 50. Each attracted by the siren call of silence that we served them up willingly.", 
                    Author = "WineDarkSailor", IsEnd = false, StoryId = new Guid("b6484081-d785-4a54-80f3-2a37f02443af")},

                new StoryPart{ PartId = new Guid("76594cb7-1114-4396-9f9b-ff7fc85ac99e"), CreatedDateTime = DateTime.Parse("11/14/2018 11:56 PM"), PartNumber = 1, 
                    PartText = "The year is 1910. Adolf Hitler, a struggling artist, has fought off dozens of assasination attemps by well meaning time travelers, but this one is different. This traveller doesn't want to kill Hitler, he wants to teach him to paint. He pulls off his hood to reveal the frizzy afro of Bob Ross.", 
                    Author = "TheSonAlsoWrites", IsEnd = false, StoryId = new Guid("c6910b8e-8a22-4a81-9fa3-6b3c152719a1")},

                new StoryPart{ PartId = new Guid("abd179d6-52b5-4498-9821-f126753471bb"), CreatedDateTime = DateTime.Parse("11/26/2018 9:40 AM"), PartNumber = 1, 
                    PartText = "Humans once wielded formidable magical power but with over 7 billion of us on the planet now Mana has spread far to thinly to have any effect. When hostile aliens reduces humanity to a mere fraction the survivors discover an old power has begun to reawaken once again.", 
                    Author = "MobyRichard", IsEnd = false, StoryId = new Guid("9350c0c1-9291-4a58-8f34-e6ff16fd4b16")},
                new StoryPart{ PartId = new Guid("7a8b501c-7bb9-44df-957b-4a54b9b8f219"), CreatedDateTime = DateTime.Parse("11/28/2018 1:20 PM"), PartNumber = 2, 
                    PartText = "I wouldn’t call it a war. Extermination maybe. Though I’d more aptly describe it as a harvest. By the time they reached our world and penetrated the stratosphere, people sought them out in droves to be harvested. Of course, they knew what that actually meant. Otherwise, they wouldn’t have been so eager.\n\n" +
                    "Ten years before the Angels descended from the sky, they had already sent what some referred to as divine retribution: a virus. Though this virus in particular only targeted women. It spread faster than a wildfire and had a 100% mortality rate. Worse yet, it was completely undetectable. In our desperation, we became animals. We locked our wives, daughters, and mothers deep underground under the constant shine of UV radiation and still they got infected. Within five years, the last woman had died leaving the rest of humanity to slowly die with her.", 
                    Author = "TheGreaterGatsby", IsEnd = false, StoryId = new Guid("9350c0c1-9291-4a58-8f34-e6ff16fd4b16")},
                new StoryPart{ PartId = new Guid("9801301c-192f-4268-a365-38df94ded618"), CreatedDateTime = DateTime.Parse("11/29/2018 4:16 PM"), PartNumber = 3, 
                    PartText = "By the time they arrived, we welcomed them with open arms into every one of our major cities. Most bowed their heads and practically begged to be killed. Some fought against them. These were the ones that still remembered the pain of watching their daughters, wives, and mothers die. They couldn’t hope to survive, but at least they could enact their own version of divine retribution.\n\n" +
                    "Looking back at it now, I know that the Angels planned for them. They wanted us to retaliate. Otherwise, where would be the fun? Men charged at them by the millions. Some to die. Some to kill. To the Angels, it was all the same.\n\n" +
                    "Until we killed the first one.", 
                    Author = "PrideAndUnprejudiced", IsEnd = false, StoryId = new Guid("9350c0c1-9291-4a58-8f34-e6ff16fd4b16")},

                new StoryPart{ PartId = new Guid("82e8a1a6-b78d-4694-92f2-105d1785ba84"), CreatedDateTime = DateTime.Parse("11/18/2018 6:38 AM"), PartNumber = 1, 
                    PartText = "Whenever you speak, people hear you speaking in their native language. Most people are surprised and delighted. The cashier at McDonalds you've just talked to is horrified. \"Nobody's spoken that language in thousands of years.\"", 
                    Author = "TheSonAlsoWrites", IsEnd = false, StoryId = new Guid("b8cfa03c-ce0a-46dd-9b19-fdff4f0b2159")},
                new StoryPart{ PartId = new Guid("07668793-5adb-4bb6-bade-db8f675b77f1"), CreatedDateTime = DateTime.Parse("11/18/2018 9:32 PM"), PartNumber = 2, 
                    PartText = "I take a deep breath as I approach the counter. The cashier has his head down, but he looks pretty generic from what I can see of him. If I'm lucky, I'll sound like I'm just another guy, trying to order my share of Chicken McNuggets.\n\n" +
                    "\"Hi, could I have a Happy Meal, please?\"\n\n" +
                    "His eyes snap to me as if magnetically attracted, and I can instantly feel the confused hostility radiate off him like heat waves. He opens his mouth to speak, closes it, and just examines me further with laser-like scrutiny.\n\n" +
                    "I'm pretty sure I must be gaping in return. Every last person in this establishment knows that they've replaced the chicken meat with something since the birds went extinct in the 2900's, but no-one's ever quite gone so far as to openly eye-murder me for my unhealthy eating choices.", 
                    Author = "TheGreaterGatsby", IsEnd = false, StoryId = new Guid("b8cfa03c-ce0a-46dd-9b19-fdff4f0b2159")},
                new StoryPart{ PartId = new Guid("5cb67a42-acd8-49e4-b954-fa0e3f2a8ab7"), CreatedDateTime = DateTime.Parse("11/20/2018 1:38 PM"), PartNumber = 3, 
                    PartText = "The man at the cashier -- Brian, his name tag reads -- slowly lifts his apron over his head and walks straight out the back door, signalling for me to follow him. A woman quickly fills in his place, attempting to smooth the situation over, but I'm already halfway out to the parking lot.\n\n" +
                    "As soon I've exited, Brian steps out from a wall, invading my personal space with absolutely no regard for it. His unusual features -- pale skin, blue eyes -- give me pause. All are traits that should technically be genetically impossible at this point.\n\n" +
                    "\"I don't know what you're--\" I try to say as soothingly as I can manage, but he shakes his head: a short, sharp jerk that cuts me off immediately.\n\n" +
                    "\"How do you know that language?\" he asks me quietly. There's something a bit off about his tone, but I can't quite place it.\n\n" +
                    "\"Look, dude, I have no idea -- \"", 
                    Author = "WineDarkSailor", IsEnd = false, StoryId = new Guid("b8cfa03c-ce0a-46dd-9b19-fdff4f0b2159")},
                new StoryPart{ PartId = new Guid("ba74b96b-578c-4b37-a74b-16422859c70a"), CreatedDateTime = DateTime.Parse("11/21/2018 3:16 PM"), PartNumber = 4, 
                    PartText = "\"No-one's spoken that language for thousands of years.\" He back-peddles until I can no longer smell his Filet-O-Fish breath in my face, and for a second I think he might let me leave, but he still blocks my way, looking at me strangely.\n\n" +
                    "\"It's just a thing I do. It's not under my control. It's another one of those implants,\" I say, pushing aside my hair to reveal the microchip embedded under my ear, where the skin is stretched tight enough to showcase its electric blue wiring." +
                    "Brian's eyes have taken on a watery sheen, and I realize with a jolt that he's crying. \"I came here three years ago in a machine,\" he tells me, his voice holding up impressively. \"I don't know how or why -- just that I woke up surrounded by useless buttons and a billion people I can't begin to understand.\" He takes a step further back, and then one more, and then somewhere along the way he's walking away fully, ignoring me standing there rooted to the ground in shock." +
                    "And then suddenly I'm not.", 
                    Author = "MobyRichard", IsEnd = false, StoryId = new Guid("b8cfa03c-ce0a-46dd-9b19-fdff4f0b2159")},

                new StoryPart{ PartId = new Guid("5dd6e0df-ef9a-46a4-9266-8d442fa3680c"), CreatedDateTime = DateTime.Parse("11/21/2018 6:42 PM"), PartNumber = 1, 
                    PartText = "Your entire life, you've been told you're deathly allergic to bees. You've always had people protecting you from them, be it your mother or a hired hand. Today, one slips through and lands on your shoulder. You hear a tiny voice say \"Your Majesty, what are your orders?\"", 
                    Author = "TheScarletWriter", IsEnd = false, StoryId = new Guid("43f854d8-11c2-4a44-b78b-b71163f8fa45")},
                new StoryPart{ PartId = new Guid("9c84325a-d9dc-41e3-a52d-9b453a39e288"), CreatedDateTime = DateTime.Parse("11/23/2018 2:38 PM"), PartNumber = 2, 
                    PartText = "He turns to look at his mother. \"Did you just hear that?\" The bee on his shoulder moved to rest behind his head.\n\n" +
                    "\"What dear?\" She missed the bee. \"Did I just hear what?\"\n\n" +
                    "\"Your Majesty, do not reveal me to her. She intends to kill me. You must remain calm.\" There was a buzzing urgency in the voice of the drone.\n\n" +
                    "\"The uh... nevermind.\" He shrugged his shoulders. \"I guess I was just hearing things.\" He moved to the refrigerator and started to assemble a sandwich. \"It's been a long day. I can hardly concentrate.\" It was true. He had been up for 16 hours so far. It was late and he needed some rest.\n\n" +
                    "The bee resting behind his ear terrified him. He wanted to scream and swat at it, but he was afraid of getting stung. He was also intrigued by the fact that apparently bees could talk. He glanced at his mother. Her face was contorted in a look of disgust.", 
                    Author = "WineDarkSailor", IsEnd = false, StoryId = new Guid("43f854d8-11c2-4a44-b78b-b71163f8fa45")},
                new StoryPart{ PartId = new Guid("c0c45366-4f3d-45d4-a93c-c98ebf887d53"), CreatedDateTime = DateTime.Parse("11/24/2018 9:22 AM"), PartNumber = 3, 
                    PartText = "\"Do I smell bees?\" She frowned and started gagging. \"I do. I do smell bees.\" She started picking at her face, as if there were a scab. Her skin grew red as she did this and the look of disgust intensified. She had horrible red splotches all over her neck and face from scratching and she started to make sounds as if she were extremely uncomfortable. \"Oh my gosh. Do you see a bee?\" Saliva was streaming down her lips and she breathing grew ragged.\n\n" +
                    "\"Mom. Are you okay?\" He grew even more alarmed. It was as if she were having the allergic reaction.\n\n" +
                    "\"I need you... to go to your room. I can't have you wandering around if there are bees in the kitchen.\" She seemed very distracted. It was quite uncharacteristic of her. \"Please. Go now. Leave.\"", 
                    Author = "TheSonAlsoWrites", IsEnd = false, StoryId = new Guid("43f854d8-11c2-4a44-b78b-b71163f8fa45")},
                new StoryPart{ PartId = new Guid("469f7884-ac62-4fb6-b14c-9c10ca8f5306"), CreatedDateTime = DateTime.Parse("11/25/2018 8:53 AM"), PartNumber = 4, 
                    PartText = "He stared at her for a long second before he grabbed his dinner plate and left. He made sure to point his ear away so that she would not see the bee. As he walked up stairs he heard a rustling and a crash that made him pause. He turned around to see his mother on the floor writhing as if in pain.\n\n" +
                    "Her eyes darkened and her skin turned ashy. He didn't understand what was going on. The flesh on her face sloughed off to reveal an insectoid visage with horrible chattering mandibles. He screamed.\n\n" +
                    "She turned to him and lunged. Too late. He was near his bedroom door and locked himself in. She was throwing herself at the door with an unstoppable rage he had never seen before.", 
                    Author = "TheGreaterGatsby", IsEnd = false, StoryId = new Guid("43f854d8-11c2-4a44-b78b-b71163f8fa45")},
                new StoryPart{ PartId = new Guid("cfb83a83-0d81-44b5-a7e1-a26791d9931c"), CreatedDateTime = DateTime.Parse("11/25/2018 8:39 PM"), PartNumber = 5, 
                    PartText = "\"Wha- what happened?\" He asked the bee this. The scraping sounds at the door persisted. There was a tearing sound that made him guess that she was using that terrible jaw to rip down the door.\n\n" +
                    "\"Your majesty, you have been kidnapped. You do not belong in this world. You are a proud prince of the Queen Bee herself. You were kidnapped as a child by wasps that wished to take control of our empire. We must hurry and leave.\" The bee moved around as it spoke, as if anxious.\n\n" +
                    "\"But how? I'm on the second floor!\" He felt terrified. The door still held, but it was shaking more than ever. A buzzing sound grew louder.\n\n" +
                    "\"Your majesty, you must shed your skin and fly.\" The bee said this as if the answer was obvious.",
                    Author = "TheScarletWriter", IsEnd = true, StoryId = new Guid("43f854d8-11c2-4a44-b78b-b71163f8fa45")},

                new StoryPart{ PartId = new Guid("2d194857-831f-4902-97af-9ceaabd67eec"), CreatedDateTime = DateTime.Now, PartNumber = 1, 
                    PartText = "You go to hell, only to find out that hell has been overturned by humans. Turns out gathering billions of the most wicked of human, among them are several ruthless but brilliant rulers, commanders, and dictators, who can no longer die, isn't such a good idea after all.", 
                    Author = "MobyRichard", IsEnd = false, StoryId = new Guid("6a6ce39c-bd3e-4508-b6f2-ff459d0d80ac")},

                new StoryPart{ PartId = new Guid("45f65015-f8d1-4586-811a-60a157458a44"), CreatedDateTime = DateTime.Parse("12/01/2018 5:26 AM"), PartNumber = 1, 
                    PartText = "At the age of twelve you started randomly seeing a green line and a red line appear on the ground. You always followed the green line and have lived a successful and happy life. Ten years later you are on top of the world, but bored. Time to see where the red line leads.", 
                    Author = "TheScarletWriter", IsEnd = false, StoryId = new Guid("39a0236b-8ad7-4242-baf4-671209f0a23d")},
                new StoryPart{ PartId = new Guid("292ff796-4c12-41ac-8ee1-ffc7f5533c2e"), CreatedDateTime = DateTime.Parse("12/01/2018 4:56 PM"), PartNumber = 2, 
                    PartText = "Everyone has seen \"The Wizard of Oz\", right? As the Munchkins said, \"follow the yellow brick road!\", so I lived my life. Though the road I followed was neither yellow, brick, nor visible to anyone but myself. I saw the lines for the first time at the age of twelve. They appeared, almost at random, as I was walking on the way home from school. One green line, leading off into one direction, and a red line going off into another. The red line was an indescribably harsh, violent shade of red, while the green line was soft and inviting like a crisp field of grass. Naturally, I followed the green line.\n\n" +
                    "At first, the green's rewards were small blessings. The first thing the line led me to was a dollar bill lying on the ground. After that, numerous mundane conveniences that I can't much recall.", 
                    Author = "WineDarkSailor", IsEnd = false, StoryId = new Guid("39a0236b-8ad7-4242-baf4-671209f0a23d")},
                new StoryPart{ PartId = new Guid("387d2054-09e3-47d7-82ac-0f7bce38ccb1"), CreatedDateTime = DateTime.Parse("12/02/2018 10:20 AM"), PartNumber = 3, 
                    PartText = "What I will never forget, is about 6 months after the lines started to guide my life, I was walking with my father. I noticed the green line veer into a nearby alleyway. I urged my dad to come with me, though I couldn't explain why. He was annoyed with me at first, but that all changed when he saw the animal lying on its side near the back of the alley, barely breathing. A small golden retriever pup, a stray that had gotten into a fight with some other animal. Dad and I hurried it to the nearest vet. I remember how surprised dad was at the fact that I knew the exact way to the clinic. He never knew I had a little help. That puppy would make a full recovery and become our loyal family dog. Mom and dad let me name it, and I chose St. Patrick. I told them it was because he was lucky we found him. Though we often shortened his name to \"Patter\" due to his habit of patting the ground with his front paws whenever he wanted attention.", 
                    Author = "TheSonAlsoWrites", IsEnd = false, StoryId = new Guid("39a0236b-8ad7-4242-baf4-671209f0a23d")},
                new StoryPart{ PartId = new Guid("6d7632b1-0891-462f-9773-0db3326531ac"), CreatedDateTime = DateTime.Parse("12/02/2018 11:42 AM"), PartNumber = 4, 
                    PartText = "Years went on, and the green line's rewards continued to grow exponentially, as did its influence on my life. I noticed one day that people who would help me would be surrounded by a green aura, while those who were no good for me had red. I learned that the hard way when I agreed to go on a date with a girl I liked in college, despite her crimson aura. Things seemed fine at first, as they usually do, only to result in one of the ugliest breakups of my life. She took my car, kicked me out of our apartment, and had Patter put to sleep as some form of retribution against me. It was then I theorized that as the rewards of the green line increase in greatness, the punishments of the red line increase equally so. At that point, I dubbed the lines \"Karmic paths\".", 
                    Author = "TheGreaterGatsby", IsEnd = false, StoryId = new Guid("39a0236b-8ad7-4242-baf4-671209f0a23d")},
                new StoryPart{ PartId = new Guid("d86d8350-3c5d-4a8c-b8c2-f59c6eb529ea"), CreatedDateTime = DateTime.Parse("12/02/2018 10:08 PM"), PartNumber = 5, 
                    PartText = "After the mishap with that girl, the green path must have thought I needed even more help. I began to see red and green words whenever I read any documents printed or digital. As I listened to people speak, I could \"hear\" the redness or the greenness of their words. I became a walking lie detector. I decided to put this into good use. I downloaded a video game off the internet, and began to read through the EULA. I could see, plain as day, the parts that were simply standard practice, and the fine print put there to prey on the buyer.\n\n" +
                    "The green path continued to lead me in this way for many more years. I decided to reap the benefits of this perceptiveness and start playing the stock market. That is how I made my fortune. I decided to spend my newfound wealth on a night out for my friends and I, which is how I met my wife at a nearby club. For a long time, things were great! I lived comfortably, loved abundantly, and hadn't a care in the world! That is, until the hue changed...", 
                    Author = "MobyRichard", IsEnd = false, StoryId = new Guid("39a0236b-8ad7-4242-baf4-671209f0a23d")},
                new StoryPart{ PartId = new Guid("34714a7e-20d7-4bcf-ae11-d53df919982e"), CreatedDateTime = DateTime.Parse("12/03/2018 1:51 PM"), PartNumber = 6, 
                    PartText = "I noticed the once vibrant green hue surrounding my best friend suddenly change to a harsh red overnight. I was dumbfounded. He was practically a brother to me, how could he do me any wrong? I continued the conversation as normally as I could, when eventually I mentioned my wife. The red around him grew more intense. The sense of dread this gave me tied my guts into knots. I choked out the words the best I could. \"Would you like to have dinner with us tonight?\" Never before has the word \"yes\" sounded so... red to me.\n\n" +
                    "When I arrived home later that night I saw what I feared most: an oppressive, red aura surrounding my wife. We exchanged the normal pleasantries, the \"welcome home!\" and the \"how was work?\", et cetera et cetera.", 
                    Author = "WineDarkSailor", IsEnd = false, StoryId = new Guid("39a0236b-8ad7-4242-baf4-671209f0a23d")},
                new StoryPart{ PartId = new Guid("5420762b-1424-4f3a-ba35-4fb9be2ca58a"), CreatedDateTime = DateTime.Parse("12/03/2018 9:28 PM"), PartNumber = 7, 
                    PartText = "I quickly shut myself up in my office and started thinking. How could things end up this way? I had followed the green path faithfully for decades! Why would it wrong me now? What can I do? Then I saw it. Convergence. The green path and the red path, perfectly perpendicular to each other. Tracing them with my eyes from my feet, across the room, and out the window of my top floor office. There they ended, together. I got up from my desk and followed them, until I was upon the window overlooking the tranquil city streets. I heard the ding of the elevator as it reached our floor. I heard my best friend and wife greet each other, then whisper something between themselves. I looked at the paths of red and green scaling the tower I had built with my choices lead downwards. I opened the window and took that last step on my path. I spent so much time enjoying the boon of the green path that I forgot the thing that remains true for both fortune and misfortune.\n\n" +
                    "This too, shall pass.", 
                    Author = "PrideAndUnprejudiced", IsEnd = true, StoryId = new Guid("39a0236b-8ad7-4242-baf4-671209f0a23d")},

                new StoryPart{ PartId = new Guid("b4296c76-154d-412a-bb6f-4ae8a5beb2de"), CreatedDateTime = DateTime.Parse("11/11/2018 4:20 PM"), PartNumber = 1, 
                    PartText = "Jesus actually had 14 disciples but their behavior was deemed inappropriate by biblical scholars, so they were removed from the final versions of the Gospels. They are Brad and Chad, the Bro-ciples, and these are their stories.", 
                    Author = "WineDarkSailor", IsEnd = false, StoryId = new Guid("e46aaa5c-6fdf-4d6f-bd74-e6ec24b2ed3a")},
                new StoryPart{ PartId = new Guid("6d872933-f510-4759-8a2c-ff9c0a1ed694"), CreatedDateTime = DateTime.Parse("11/12/2018 1:14 PM"), PartNumber = 2, 
                    PartText = "Rad 2:1\n\n" +
                    "On the fifth week day a bachelor party took place at Cana in Galilee. Jesus had been invited, along with a plus one. So Jesus brought his apostle Chad as his plus one, and Brad as Chad's plus one's plus one.\n\n" +
                    "Chad scoped out the joint before turning to Jesus and saying to him, \"JC, my man. There is nowhere near enough wine here for all of these people to get plastered.\"\n\n" +
                    "\"So be it,\" Jesus replied. \"Bring me the barrels of wine.\"\n\n" +
                    "Brad and Chad began to lift the barrels before turning to Jesus once more. \"JC, could you just come over here? It would be a lot easier. These are heavier than a man-eating whale!\"\n\n" +
                    "So Jesus approached the barrels of wine and blessed them. Chad filled a chalice from the barrel and took a sip.\n\n" +
                    "Chad sung with joy, \"Hard liquor! The Lord has blessed us with hard liquor!\"\n\n" +
                    "And so all the guests got turnt higher than the heavens.", 
                    Author = "TheSonAlsoWrites", IsEnd = false, StoryId = new Guid("e46aaa5c-6fdf-4d6f-bd74-e6ec24b2ed3a")},
                new StoryPart{ PartId = new Guid("37a65d90-ae23-42d2-8792-4cbac83a0029"), CreatedDateTime = DateTime.Parse("11/14/2018 9:46 PM"), PartNumber = 3, 
                    PartText = "Rad 9:9\n\n" +
                    "As Jesus went along, he saw a man deaf from birth. Brad asked Christ, \"Yo JC, why must this man be deaf? Does he inherit the punishment of his parents' sins?\"\n\n" +
                    "\"Neither this man nor his parents sinned,\" replied Jesus, \"Well, I mean, I'm sure they've all sinned multiple times at many points throughout their lives. That's not why he's deaf, though.\"\n\n" +
                    "Chad asked Christ, \"JC, could you get some miracle whip going and let him hear the voices of friends and cackling of fire? That would be sicker than a leper that hasn't touched you.\"\n\n" +
                    "\"So be it,\" Jesus said, \"my dudes.\"\n\n" +
                    "Then Jesus caked mud onto the man's ears. The deaf man, confused, slapped Jesus' cheek. Jesus turned his face, exposing his other cheek.\n\n" +
                    "Chad asked the deaf man, \"Hey bozo, you copy?\"\n\n" +
                    "The deaf man made a noise that only someone that has been deaf for their whole life up until this moment would make. And so he could hear.", 
                    Author = "MobyRichard", IsEnd = false, StoryId = new Guid("e46aaa5c-6fdf-4d6f-bd74-e6ec24b2ed3a")},
                new StoryPart{ PartId = new Guid("bdc734e1-76f7-4a3a-9488-14cbbe97284f"), CreatedDateTime = DateTime.Parse("11/15/2018 12:16 PM"), PartNumber = 4, 
                    PartText = "Rad 14:13\n\n" +
                    "When Jesus arrived in Judea he saw a large crowd before him. He showed compassion on them and healed their sick.\n\n" +
                    "As the sun set, Brad said to Jesus, \"These people look like they're starving, JC. Send them all home with enough money to buy themselves food.\"\n\n" +
                    "Jesus looked out to the crowed and replied to Brad, \"I will not give them riches. I just told you this earlier- blessed are the poor, for theirs is the kingdom of God. Hand me your fish sandwich.\"\n\n" +
                    "Brad replied, \"JC, you have been touching sick people all day. But if that is your will, then it shall be done.\"\n\n" +
                    "And so Brad gave Jesus his fish sandwich. Jesus gave thanks to the lord and split the sandwich. Then he handed a piece of the sandwich to the people in the crowd. They all ate and were satisfied. Those who ate were about four hundred.\n\n" +
                    "Chad said to Jesus, \"JC you clever man! Instead of handing these people riches to buy food, you hand them food to eat. Do not ever let a Jew tell you that you are not one of them!\"", 
                    Author = "TheScarletWriter", IsEnd = false, StoryId = new Guid("e46aaa5c-6fdf-4d6f-bd74-e6ec24b2ed3a")},
                new StoryPart{ PartId = new Guid("4af864f1-5338-4d7a-b39c-905d7b1d4b43"), CreatedDateTime = DateTime.Parse("11/16/2018 9:42 AM"), PartNumber = 5, 
                    PartText = "Rad 6:9\n\n" +
                    "When Jesus arrived at the Temple, he looked out unto the masses with Chad.\n\n" +
                    "Thus spake He and said \"Let the bond between men of equal stature never be torn asunder, and let their brotherly love be known as kin to blood relation.\"\n\n" +
                    "Chad asked of Jesus \"Oh, Lord, and what of the woman, whom man so covets? Can she not turn him away from his brother?\"\n\n" +
                    "And Jesus said unto Chad \"The bond of man will triumph over basely desire, and Bro shall come before Hoe.\"", 
                    Author = "TheSonAlsoWrites", IsEnd = false, StoryId = new Guid("e46aaa5c-6fdf-4d6f-bd74-e6ec24b2ed3a")},


                new StoryPart{ PartId = new Guid("bca47959-58f1-4db6-a0ff-96b137f49b55"), CreatedDateTime = DateTime.Parse("12/02/2018 11:13 AM"), PartNumber = 1, 
                    PartText = "They say you die twice. One time when you stop breathing and a second time, a bit later on, when somebody says your name for the last time. What they don’t say is that in between those deaths, you get stuck in purgatory with all the great philosophers and authors - all just waiting to die.", 
                    Author = "TheScarletWriter", IsEnd = false, StoryId = new Guid("4d5eb60b-ef05-4785-95cf-c99b12550a77")},

                new StoryPart{ PartId = new Guid("1f3579f9-446b-4c6a-b8f9-c04e1dc02786"), CreatedDateTime = DateTime.Parse("11/30/2018 6:52 PM"), PartNumber = 1, 
                    PartText = "The Sol system was an experiment by aliens to determine if life would evolve under hyper hostile physics. Unfortunately, it was forgotten about. Years later, humans are leaving the solar system, only to discover that upon passing an invisible barrier, they essentially gain superpowers.", 
                    Author = "WineDarkSailor", IsEnd = false, StoryId = new Guid("d2ceb713-a3ba-403d-b5ed-b1b3d089e3b6")});

            context.SaveChanges();

            IList<Story> stories = context.Stories.ToList();
            IList<StoryPart> storyParts = context.StoryParts.ToList();

            foreach (Story s in stories)
            {
                foreach (StoryPart sp in storyParts)
                {
                    if (sp.StoryId == s.StoryId && sp.StoryName == null)
                    {   
                        sp.StoryName = s.StoryName;
                        sp.Story = s;
                        var index = sp.PartNumber - 1;
                        s.Parts[index] = sp;
                    }
                    context.StoryParts.AddOrUpdate(sp);
                }
                context.Stories.AddOrUpdate(s);
            }

            context.SaveChanges();

        }
    }
}
