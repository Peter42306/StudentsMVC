﻿using Microsoft.EntityFrameworkCore;

namespace StudentsMVC.Models
{
    // Контекст данных для работы с базой данных
    public class MovieContext:DbContext
    {
        // Набор данных фильмов
        public DbSet<Movie> Movies { get; set; }

        // Конструктор, принимающий параметры настройки контекста базы данных
        public MovieContext(DbContextOptions<MovieContext>options):base(options)
        {
            // Проверка и создание базы данных при её отсутствии
            if (Database.EnsureCreated())
            {
                // Добавление тестовых данных, если база данных создана в первый раз
                Movies?.Add(new Movie
                {
                    Title = "Жил-был пёс",
                    Director = "Эдуард Назаров",
                    Genre = "Комедия",
                    ReleaseYear = 1982,
                    PosterPath = "/Image/JilBilPios.jpg",
                    Description = "Мультфильм Эдуарда Назарова пересказывает украинскую народную сказку о псе, который решил доказать хозяевам свою значимость и договорился с волком инсценировать похищение ребёнка. Легендарные фразы «Щас спою» и «Ты заходи, если что» наверняка знает каждый."
                });

                Movies?.Add(new Movie
                {
                    Title = "Винни-Пух",
                    Director = "Фёдор Хитрук",
                    Genre = "Сказка",
                    ReleaseYear = 1969,
                    PosterPath = "/Image/Vinni-Pux_1659775582-630x315.jpg",
                    Description = "Главные герои трилогии мультфильмов по книге Алана Александра Милна ходят друг к другу в гости, празднуют день рождения Ослика и пытаются добыть мёд у пчёл. При всей наивности сюжета мудрые высказывания Винни-Пуха, говорящего голосом Евгения Леонова, давно разошлись на цитаты."
                });

                Movies?.Add(new Movie
                {
                    Title = "Как львёнок и черепаха пели песню",
                    Director = "Инесса Ковалевская",
                    Genre = "Музыкальный",
                    ReleaseYear = 1974,
                    PosterPath = "/Image/KakLvenokBCherepahaPeliPesnyu.jpg",
                    Description = "Львёнок Ррр-Мяу гуляет по лесу и слышит песню, которую исполняет большая черепаха. И они решают спеть её дуэтом."
                });

                Movies?.Add(new Movie
                {
                    Title = "Каникулы Бонифация",
                    Director = "Фёдор Хитрук",
                    Genre = "Приключения",
                    ReleaseYear = 1965,
                    PosterPath = "/Image/Kanikuly-Bonifaciya_1659775259-630x315.jpg",
                    Description = "Цирковой лев Бонифаций отправляется на каникулы в Африку. Но и там он продолжает развлекать детишек своим творчеством."
                });

                Movies?.Add(new Movie
                {
                    Title = "Приключения кота Леопольда",
                    Director = "Аркадий Хайт",
                    Genre = "Комедия, приключения",
                    ReleaseYear = 1975,
                    PosterPath = "/Image/KOT-LEOPOLD-1_1601569276-630x315.jpg",
                    Description = "Знаменитое противостояние добродушного кота и вредных мышей началось с мультфильма «Месть кота Леопольда», где герой выпил лекарство «Озверин», но знакомый визуальный ряд серия обрела только с третьего эпизода о поисках клада. Всего вышло 11 мультфильмах об этих героях. В последнем мыши угнали у Леопольда автомобиль, в котором оказалось множество необычных функций."
                });

                Movies?.Add(new Movie
                {
                    Title = "Малыш и Карлсон",
                    Director = "Борис Степанцов",
                    Genre = "Малыш и Карлсон",
                    ReleaseYear = 1968,
                    PosterPath = "/Image/Malysh-i-Karlson-01_1601569258-630x315.jpg",
                    Description = "Вольный пересказ сказки Астрид Линдгрен посвящён Малышу, который знакомится с Карлсоном — «мужчиной в самом расцвете сил». Тот любит хулиганить и обожает варенье. А ещё у Карлсона за спиной пропеллер."
                });

                Movies?.Add(new Movie
                {
                    Title = "Ну, погоди!",
                    Director = "Аркадий Хайт",
                    Genre = "Комедия",
                    ReleaseYear = 1969,
                    PosterPath = "/Image/nu-pogodi_1659775885-630x315.jpg",
                    Description = "Один из самых популярных советских мультсериалов рассказывает о забавном противостоянии хулигана Волка и скромного и сообразительного Зайца. Изначально вышло 16 эпизодов. В 90-е годы досняли ещё два, используя старые записи голоса уже скончавшегося Анатолия Папанова. В 2006-м добавилось ещё две серии уже с новыми актёрами озвучки. А в будущем планируют перезапустить историю, адаптировав сюжет под новые времена."
                });

                Movies?.Add(new Movie
                {
                    Title = "Приключения капитана Врунгеля",
                    Director = "Давид Черкасский",
                    Genre = "Приключения, музыкальный",
                    ReleaseYear = 1976,
                    PosterPath = "/Image/PrikluchenijaKapitanaVrungelya.jpg",
                    Description = "Знаменитый Давид Черкасский снял музыкальную версию книги Андрея Некрасова. К основному сюжету добавили историю с похищением античной статуи и шпионские игры. А ещё Черкасский совместил анимацию со съёмками настоящего моря."
                });

                Movies?.Add(new Movie
                {
                    Title = "Тайна третьей планеты",
                    Director = "Роман Качанов",
                    Genre = "Фантастика, приключения",
                    ReleaseYear = 1981,
                    PosterPath = "/Image/TainatretieiPlaneta.jpg",
                    Description = "Юная Алиса отправляется со своим отцом и капитаном Зелёным на поиски редких животных для зоопарка. Однако вместо этого им предстоит разгадать тайну исчезновения двух капитанов и даже сразиться с космическими пиратами. Изначально в повести Кира Булычёва «Путешествие Алисы» капитанов было трое, да и сюжет закручивался намного сложнее. Но после появления популярного мультфильма автор переписал книгу, создав более лёгкий детский вариант."
                });

                Movies?.Add(new Movie
                {
                    Title = "Умка",
                    Director = "Владимир Пекарь",
                    Genre = "Сказка, приключения",
                    ReleaseYear = 1969,
                    PosterPath = "/Image/Umka.jpg",
                    Description = "Наивный медвежонок Умка знакомится с чукотским мальчиком. Юные герои становятся друзьями, но вскоре люди покидают местность. В продолжении же Умка решает найти своего нового знакомого и отправляется на полярную станцию."
                });

                // Сохранение изменений в базе данных
                SaveChanges();
            }
        }
    }
}
