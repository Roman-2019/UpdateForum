namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DAL.DBContext";
        }


        public class MyContextInitializer : DropCreateDatabaseAlways<DBContext>
        {
            protected override void Seed(DBContext context)
            {

                context.Authors.Add(new Author { NickName = "Kolya", Status = "user", CountComments = 0 });
                context.Authors.Add(new Author { NickName = "Vasya", Status = "experienced user", CountComments = 20 });
                context.Authors.Add(new Author { NickName = "Yura", Status = "advanced user", CountComments = 50 });
                context.Authors.Add(new Author { NickName = "Kostya", Status = "guru user", CountComments = 100 });

                context.Categories.Add(new Category { Title = "Humor", Discription = "A smile is a sign of good mood." });
                context.Categories.Add(new Category { Title = "Fishing", Discription = "As for fishing - fishing spots, tackle, bait, etc." });
                context.Categories.Add(new Category { Title = "Auto", Discription = "News, reviews, desires." });
                context.Categories.Add(new Category { Title = "Games", Discription = "Games - news, strategies, walkthroughs, etc." });

                context.Tags.Add(new Tag { Text = "Humor" });
                context.Tags.Add(new Tag { Text = "good" });
                context.Tags.Add(new Tag { Text = "fish" });
                context.Tags.Add(new Tag { Text = "bait" });
                context.Tags.Add(new Tag { Text = "review" });
                context.Tags.Add(new Tag { Text = "Auto" });
                context.Tags.Add(new Tag { Text = "new" });
                context.Tags.Add(new Tag { Text = "game" });

                context.SaveChanges();                

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Fishing"),
                    DateTime = DateTime.Today,
                    Text = "И сразу – главный секрет: при выборе удочки, в первую очередь нужно обращать внимание на ее вес и " +
                    "эргономичность (удобство в использовании). Если удилище тяжелое (опытные рыбаки знают, что крепатура в руках " +
                    "бывает даже после 100-граммовой удочки), вы быстро устанете делать забросы. А слишком малый вес, скорее всего, " +
                    "свидетельствует о плохом качестве и дешевых материалах." +
                    "Перед тем, как покупать, желательно подержать удочку в руках, хотя большинство современных производителей" +
                    "(Graphiteleader, Daiwa, Salmo, DAM и др.) не ленятся уделять внимание такому аспекту, " +
                    "как удобство конструкции бланка.Выбирайте поплавочные удочки проверенных брендов – и не ошибетесь." +
                    "Покупка удилищ на grenka.ua – гарантированный способ не прогадать с выбором.",
                    Title = "Как выбрать и оснастить поплавочную удочку"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Fishing"),
                    DateTime = DateTime.Today,
                    Text = "Профессиональное оборудование для рыбалки — это и спиннинги, и бескатушечные профессиональные удочки " +
                    "махового типа, и оснастка, аксессуары для подводной охоты. В этом вопросе важно всё. Профессиональные удочки " +
                    "производятся из композитных материалов. Основа таких материалов - углеволокно и стеклопластик. Топовых моделей " +
                    "профессиональных удочек много. Это, например: " +
                    "• Профессиональные удочки Shimano Beastmaster DX FeeDer. Рабочая длина вариативна: от 2,74 до 3,35 метров. " +
                    "Эта модель универсальная и дальнобойная." +
                    "• Профессиональные удочки Sabaneev Master Pole 600 - прочные, подходящие даже для новичков маховые длинные " +
                    "удилища." +
                    "• Профессиональные удочки Волжанка 3,6 м. матчевой конструкции состоят из трёх частей. Бланк из " +
                    "высокомодульного графита IM7 обеспечивает хорошую работу удилища. Подходит для опытных поклонников поплавочной " +
                    "ловли." +
                    "Все профессиональные удочки имеют гарантию производителя.",
                    Title = "Профессиональные удочки"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Auto"),
                    DateTime = DateTime.Today,
                    Text = "ffgghghgguuhhuhhhhuuuhhj13 rtuityug",
                    Title = "Classic auto"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                   // AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Humor"),
                    DateTime = DateTime.Today,
                    Text = "ffgghghgguuhhuhhhhuuuhhj13 123",
                    Title = "Black humor"
                });

                context.SaveChanges();

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать и оснастить поплавочную удочку"),
                    DateTime = DateTime.Today,
                    Text = "ffgghghgguuhhuhhhhuuuhhj13 hjlhjkhcjghjb",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать и оснастить поплавочную удочку"),
                    DateTime = DateTime.Today,
                    Text = "фдажвпдалвпщльмслти hjlhjkhcjghjb",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать и оснастить поплавочную удочку"),
                    DateTime = DateTime.Today,
                    Text = "ffgghghgguuhhuhhhhuuuhhj13 щукешшоаьалвиоавлдалплва",
                });
                context.Comments.Add(new Comment
                {
                    AuthorId = context.Authors.Single(x => x.NickName == "Vasya").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Classic auto"),
                    DateTime = DateTime.Today,
                    Text = "eesxeseesesscrdrcdsstfcfxdxcxdsddfxdsddxdsddd fdfgcfddr rdyuh l ",
                });
                context.Comments.Add(new Comment
                {
                    AuthorId = context.Authors.Single(x => x.NickName == "Yura").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Classic auto"),
                    DateTime = DateTime.Today,
                    Text = "okknhjnbhvcdxddg cxfgbh  ghhufxxbbkjddhfcvmb mhfghlj  hjgyg",
                });

                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        }
    }
}
