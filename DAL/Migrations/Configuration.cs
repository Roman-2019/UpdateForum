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


        public class MyContextInitializer : DropCreateDatabaseIfModelChanges<DBContext>
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
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Fishing"),
                    DateTime = DateTime.Today,
                    Text = "На реке гораздо проще найти уловистое место, которое может отличаться от общего фона или " +
                    "выделяться на нем. Если река извилистая, то на ней очень легко определить характер дна реки, опираясь на рисунок " +
                    "береговой линии. Как правило, на таких реках отчетливо выделяются обрывы, возле которых река может иметь " +
                    "оптимальные глубины, на которых можно найти большинство видов рыб, ведущих придонный образ жизни. На извилистых " +
                    "реках характер течения воды зависит от величины изгибов, а глубины можно определять по цвету воды." +
                    "Перспективные места для лова рыбы на реке" +
                    "Ими могут быть заливы, старицы и излучины.Внешние берега излучин формируют обрывы, где имеются наиболее " +
                    "глубокие места, а внутренние берега – отмели.На узких участках реки, где имеются слабые течения, отмечаются " +
                    "более глубокие места, нежели на широких.В районах перекатов легко определить более глубокое место по цвету воды, " +
                    "которая в таких местах имеет более темный цвет.Ниже по течению, если идти от переката образуются, так называемые " +
                    "омуты, или глубокие ямы, где непременно находится более крупная рыба и хищники.Более слабое течение на плесах, " +
                    "нежели на перекатах.Глубина плесов более постоянна и может плавно измениться от берегов к стрежени, где " +
                    "присутствует самое быстрое течение.",
                    Title = "Как выбрать место для рыбалки на реке"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Auto"),
                    DateTime = DateTime.Today,
                    Text = "Этот вид машин  используют на различного рода соревнованиях. Такие автомобили обычно не перемещаются " +
                    "по дорогам общего назначения, а только на спортивных трассах. Такие автомобили обычно рассчитаны на одного или " +
                    "двух человек. Они значительно превосходят по техническим характеристикам автомобили общего назначения. " +
                    "Спортивные автомобили делятся по типу соревнований, для которых они предназначены. Выделяют несколько основных " +
                    "типов гоночных автомобилей: — для гонок по кольцу, эта замкнутые трассы с множеством поворотов; — картинги, " +
                    "это автомобили, не имеющие кузова, но имеющие двигатель от мотоцикла — для ралли, соревнования на пересеченной " +
                    "местности или дороге с продолжительностью от 1 до 3 дней; — для ралли-рейдов, такие соревнования проводятся " +
                    "также как и ралли, но продолжительностью до нескольких месяцев; — для кроссов, соревнование кольцевой гонки по " +
                    "дорогам или пересеченной местности. Разобравшись в видах и классификациях автомобилей, новую тему про виды " +
                    "двигателей автомобилей можно прочитать на новой странице.",
                    Title = "Гоночные автомобили"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Auto"),
                    DateTime = DateTime.Today,
                    Text = "Тент, полуприцеп. Самый популярный вид грузовика, способен перевозить большое разнообразие грузов. " +
                    "Загрузка может осуществляться сбоку, сзади, сверху. Грузоподъемность до 25 тонн, объем полезного пространства " +
                    "грузового отсека может быть до 100 кубических метров. Изотерм, рефрижератор.Данный автомобиль может груз в " +
                    "определенных термических условиях, в основном продукты питания.Рабочий диапазон поддержания температуры " +
                    "груза от + 25 до - 25 градусов Цельсия.Эксплуатация такого типа автомобиля дороже до 25 %, чем обычного. " +
                    "Контейнеровоз.Пригоден для транспортировки различных контейнеров.Грузоподъемность достигает 30 тонн. " +
                    "Открытая бортовая.У автомобиля иметься борт, удерживающий груз на платформе.Предназначен для перевозки " +
                    "различных грузов, которые могут выдерживать воздействие погодных явлений. Открытая платформа. Приспособлена " +
                    "для перевозки грузов, которые могут выдерживать воздействие погодных явлений. Автоцистерна.Используется для " +
                    "перевозки жидких грузов.Объем перевозимой жидкости может достигать 40 кубических метров. Автовоз. Дает " +
                    "возможность для перевозки несколько легковых автомобилей на специальной платформе. Зерновоз. Приспособлен для " +
                    "перевозки зерна. Самосвал.Этот вид грузовика используется для транспортировки сыпучих грузов. Грузоподъемность " +
                    "может достигать до 22 тонн. Лесовоз.Он предназначен для перевозки длиномерного груза, например труб или леса. " +
                    "Для более экономически выгодного и быстрого перемещения груза необходимо правильно подобрать вид грузовика, " +
                    "его грузоподъемность и характеристики.",
                    Title = "Грузовые автомобили"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Humor"),
                    DateTime = DateTime.Today,
                    Text = "Юмор (англ. humour – причуда, настроение, нрав, комизм, юмор), вид комического, добродушный смех с " +
                    "серьезной подоплекой. Слово «юмор» восходит к латинскому humor – жидкость: считалось, что четыре телесных " +
                    "жидкости определяют четыре темперамента, или характера. Одним из первых это слово использовал в литературе " +
                    "Б. Джонсон, создавший в конце 16 века комедии «Всяк со своей причудой» и «Всяк вне своих причуд» " +
                    "(буквально «в своем юморе» и «вне своего юмора), – но еще в сатирическом, не закрепившемся значении ущербной " +
                    "односторонности характера (глухота, алчность и т. д.). Впоследствии С. Т. Колридж в статье «О различии " +
                    "остроумного, смешного, эксцентричного и юмористического» (1808 – 1811) цитировал стихи Б. Джонсона о жидкостях: " +
                    "крови, флегме, желчи светлой и темной, которые «характером и нравом управляют», и определял юмор в новом смысле: " +
                    "это «необычная связь мыслей или образов, производящая эффект неожиданного и тем доставляющая удовольствие. " +
                    "«Юмор выделяется среди других видов остроумного, которые безличны, не окрашены индивидуальным пониманием и " +
                    "чувством.По крайней мере, в высоком юморе всегда есть намек на связь с некой идеей, по природе своей не конечной, " +
                    "но конечной по форме…». Английский романтик оговаривал бескорыстность юмора, его сходство с «пафосом», называл " +
                    "отмеченные им литературные образы: таковы Фальстаф у Шекспира, персонажи Л.Стерна, Т.Дж.Смоллетта.Юмор для " +
                    "Колриджа – «состояние души, ее трудно определимая одаренность, талант, который придает насмешливую остроту " +
                    "всему, что она в себя впитывает повседневно и ежечасно, а вместе с тем в человеке с юмором нет ничего особенного, " +
                    "он так же, как и мы, сбивается с пути, делает промахи, совершает ошибки». ",
                    Title = "История юмора"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Vasya"),
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Humor"),
                    DateTime = DateTime.Today,
                    Text = "Анекдо́т (фр. anecdote — краткий рассказ об интересном случае; от греч. τὸ ἀνέκδοτоν — не опубликовано, " +
                    "букв. «не изданное»[1]) — фольклорный жанр, короткая смешная история, обычно передаваемая из уст в уста. " +
                    "Чаще всего анекдоту свойственно неожиданное смысловое разрешение в самом конце, которое и рождает смех. Это " +
                    "может быть игра слов или ассоциации, требующие дополнительных знаний: социальных, литературных, исторических, " +
                    "географических и т. д. Тематика анекдотов охватывает практически все сферы человеческой деятельности. В " +
                    "большинстве случаев авторы анекдотов неизвестны. В качестве алгоритма формы выступает пародическое использование, " +
                    "имитация исторических преданий, легенд, натуральных очерков и т.п.В ходе импровизированных семиотических " +
                    "преобразований[2] рождается текст, который, вызывая катарсис, доставляет эстетическое удовольствие.Упрощённо " +
                    "говоря, анекдот — это бессознательно проступающее детское речевое творчество.Возможно, отсюда характерное " +
                    "старинное русское название — байка[3]. В России XVIII—XIX вв. (и в многочисленных языках мира до сих пор) " +
                    "слово «анекдот» имело несколько иное значение — это могла быть просто занимательная история о каком - нибудь " +
                    "известном человеке, необязательно с задачей его высмеять(ср.у Пушкина: «Дней минувших анекдоты»).Классикой " +
                    "того времени стали называть такие «анекдоты» про Потёмкина. ",
                    Title = "Анекдот"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Humor"),
                    DateTime = DateTime.Today,
                    Text = "Черный юмор - это шутки, от которых сначала смешно, а потом немного стыдно за то, что было смешно. " +
                    "А некоторым после чернухи вообще несмешно, им сразу грустно, стыдно, противно и черт - те знает что еще." +
                    "Потому что чувство юмора как ноги: у кого - то есть, а у кого - то нет.",
                    Title = "Черный юмор"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Games"),
                    DateTime = DateTime.Today,
                    Text = "В Steam открыли страницы Heavy Rain, Detroit: Become Human и Beyond: Two Souls, где также можно " +
                    "загрузить демоверсии. Официально проекты пока недоступны в магазине Valve, а датой выхода указано " +
                    "туманное «Выйдет скоро». Разработчики при этом официально ничего не объявляли, а в Epic Games Store игры " +
                    "вышли меньше года назад — в июне, июле и декабре соответственно. Обычно эксклюзивность магазина составляет " +
                    "12 месяцев(в случае Borderlands 3 — 6 месяцев).Не исключено, что игры появятся в Steam лишь спустя какое - то время. ",
                    Title = "В Steam внезапно появились демки"
                });
                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Games"),
                    DateTime = DateTime.Today,
                    Text = "CCP Games объявила, что с 1 июля повысит цены в EVE Online для российского региона. Главная " +
                    "причина проста — удешевление рубля по отношению к американскому доллару.Вдобавок рублёвые цены не " +
                    "менялись уже шесть лет, поэтому пришло время актуализировать их. По словам разработчиков, разницей в " +
                    "цене пользуются злоумышленники, которые через VPN - сервисы обходят региональные цены и негативно влияют " +
                    "на баланс — как внутри игры, так и за её пределами. Увеличение цены затронет подписку «Омега», плексы, " +
                    "программы обучения пилотов, разные наборы и ежедневные альфа - инъекторы.",
                    Title = "EVE Online: в июле повысят цены"
                });
                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Games"),
                    DateTime = DateTime.Today,
                    Text = "Издательство No More Robots и студия Broken Bear Games выпустили в Steam ролевой боевик Family Man, " +
                    "который во многих отношениях напоминает культовый сериал «Во все тяжкие». Разве что выполнен в кубической " +
                    "манере и позволяет выбрать собственный путь. Главный герой игры остаётся без работы и с семьёй на попечении." +
                    "Чтобы выжить, ему приходится одалживаться у мафии, а подобные долги не подлежат забвению.Теперь у него всего " +
                    "месяц на то, чтобы отработать всё до последнего доллара и при этом не оставить без внимания семью. Игра получает " +
                    "хорошие отзывы: 80 % отзывов положительные, а из отрицательных часть вызвана релизными багами.Но создатели " +
                    "уже выпустили первый патч, который не только чинит ряд ошибок, но и добавляет новые возможности.Например, " +
                    "достижение за все полученные варианты концовок. Заодно, по просьбам игроков, в Family Man добавили «итоговое» " +
                    "окно: выходя из игры, можно увидеть, сколько всего осталось не пройденным и не найденным, чтобы наверстать " +
                    "упущенное в следующий раз.",
                    Title = "Уолтер Уайт в кубе: состоялся релиз Family Man"
                });

                context.SaveChanges();

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать и оснастить поплавочную удочку"),
                    DateTime = DateTime.Today,
                    Text = "Поплавочная удочка — одна из простейших рыболовных снастей, что обусловило её повсеместное распространение.",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать и оснастить поплавочную удочку"),
                    DateTime = DateTime.Today,
                    Text = "Поплавочные удочки для рыбалки в X-Zone ☎ (044) 303-98-85 ⭐ Лучшая цена на поплавочные удилища Salmo, Daiwa, Cormoran",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать и оснастить поплавочную удочку"),
                    DateTime = DateTime.Today,
                    Text = "Длина удилища поплавочной удочки может иметь длину от десятка сантиметров до 18 метров.",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Профессиональные удочки"),
                    DateTime = DateTime.Today,
                    Text = "Большая Okuma / Okuma для гигантской рыбы - гигантский марлин / тунец / морской окунь ... и т.д." +
                    "Okuma предлагает разнообразные удочки для крупной дичи с высококачественным дизайном",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Профессиональные удочки"),
                    DateTime = DateTime.Today,
                    Text = "Удочки нахлыстом Okuma предназначены главным образом для форели и лосося при любом типе речной рыбалки.",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Профессиональные удочки"),
                    DateTime = DateTime.Today,
                    Text = "Okuma Bass Rods предназначены для турнирной ловли баса, особенно для профессиональных рыболовов.",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать место для рыбалки на реке"),
                    DateTime = DateTime.Today,
                    Text = "Поиск лучшего места для рыбалки – задача нетривиальная",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать место для рыбалки на реке"),
                    DateTime = DateTime.Today,
                    Text = "Реки на равнинах имеют искривленные, а не прямые русла.",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Как выбрать место для рыбалки на реке"),
                    DateTime = DateTime.Today,
                    Text = "В реке, даже незначительное отклонение в сторону может иметь решающее значение, поскольку " +
                    "рыба тоже «ходит» своей дорогой.",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Vasya").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Гоночные автомобили"),
                    DateTime = DateTime.Today,
                    Text = "Формула-1 рулит!",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Гоночные автомобили"),
                    DateTime = DateTime.Today,
                    Text = "Где взять актуальный рейтинг гоночных автомобилей?",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Гоночные автомобили"),
                    DateTime = DateTime.Today,
                    Text = "Какие гоночные автомобили были в СССР?",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Грузовые автомобили"),
                    DateTime = DateTime.Today,
                    Text = "Грузовые автомобили MAN — курс на успех. ",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Грузовые автомобили"),
                    DateTime = DateTime.Today,
                    Text = "AUTO.RIA – Грузовые авто бу в Украине",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Yura"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Грузовые автомобили"),
                    DateTime = DateTime.Today,
                    Text = "Единственное условие, перед покупкой грузового автомобиля конкретного вида и марки " +
                    "следует в точности знать те функции, которые автомобиль будет осуществлять, то есть, какие грузы " +
                    "он будет перевозить.",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "История юмора"),
                    DateTime = DateTime.Today,
                    Text = "Юмор – преодоление препятствий на пути вклада в общественное производство жизни",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "История юмора"),
                    DateTime = DateTime.Today,
                    Text = "Ржу ни могу!!!",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "История юмора"),
                    DateTime = DateTime.Today,
                    Text = "Остроумие также разделяет с юмором иллокутивную силу комичности",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Vasya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Анекдот"),
                    DateTime = DateTime.Today,
                    Text = "Если президент, выйдя из бункера, увидит свою тень, то карантин продлится ещё шесть недель.",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Vasya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Анекдот"),
                    DateTime = DateTime.Today,
                    Text = "Армянское радио спрашивают:- А почему наши артисты Розенбаум, Газманов - старшие офицеры и орденами" +
                    " увешаны ? Армянское радио отвечает: -Видимо, когда они поют - по ним стреляют...",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Vasya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Анекдот"),
                    DateTime = DateTime.Today,
                    Text = "Только что какой-то придурок летел по городу 190 км/ч, вообще конченый, " +
                    "бывают же такие придурки! Еле обогнал его.",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Черный юмор"),
                    DateTime = DateTime.Today,
                    Text = "Маленький мальчик по стройке гулял, В бетономешалку случайно попал. " +
                    "Мальчика мама пошла в магазин - Ей из стены улыбается сын!",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Черный юмор"),
                    DateTime = DateTime.Today,
                    Text = "Маленький мальчик с папой курил  Где у нас лифт ? -он у папы спросил." +
                    "На мусоропровод отец показал, долго костями сынок грохотал.",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Черный юмор"),
                    DateTime = DateTime.Today,
                    Text = "Маленький мальчик в прятки игрался, В духовку решительно очень забрался." +
                    "Мама не знала об этой игре - Будет жаркое на ужин в семье!",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "В Steam внезапно появились демки"),
                    DateTime = DateTime.Today,
                    Text = "Так внезапно и конец света настанет",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "В Steam внезапно появились демки"),
                    DateTime = DateTime.Today,
                    Text = "Это не игры - это кино. тогда получается что это не демки а трейлеры",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "В Steam внезапно появились демки"),
                    DateTime = DateTime.Today,
                    Text = "Есть игры в которые нужно играть исключительно на приставке.",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Vasya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "EVE Online: в июле повысят цены"),
                    DateTime = DateTime.Today,
                    Text = "искренне люблю еву, но на нынешнем этапе там кроме ботов еще кто-то остался? последний " +
                    "раз логинился лет 6 назад.",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "EVE Online: в июле повысят цены"),
                    DateTime = DateTime.Today,
                    Text = "Очень тревожный звонок. Как бы остальных игр это не коснулось",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Vasya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "EVE Online: в июле повысят цены"),
                    DateTime = DateTime.Today,
                    Text = "все для россиян! дешевеет рубль -повысим млять цены!",
                });

                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Уолтер Уайт в кубе: состоялся релиз Family Man"),
                    DateTime = DateTime.Today,
                    Text = "Время варить!",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kolya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Уолтер Уайт в кубе: состоялся релиз Family Man"),
                    DateTime = DateTime.Today,
                    Text = "Не, время тащить!",
                });
                context.Comments.Add(new Comment
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Vasya"),
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Уолтер Уайт в кубе: состоялся релиз Family Man"),
                    DateTime = DateTime.Today,
                    Text = "Да уже всех вытащили)))",
                });

                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        }
    }
}
