create database Anime;
USE Anime;
create table info
(animeId int,
 anime_title varchar(100) NOT NULL, 
 anime_director varchar(100) NOT NULL, 
 anime_episodes int NOT NULL, 
 anime_status varchar(100) NOT NULL,
 PRIMARY KEY (animeId)
 );

create table theme
(anime_info_id int,
anime_theme varchar(100) NOT NULL, 
anime_genres varchar(100) NOT NULL,
 anime_studio varchar(100) NOT NULL,
 original_title varchar(100) NOT NULL,
 PRIMARY KEY(anime_info_id));
 
ALTER TABLE info ADD COLUMN anime_info_id INT;
ALTER TABLE info ADD constraint fk FOREIGN KEY(anime_info_id) REFERENCES theme(anime_info_id);

insert into info (animeId, anime_title, anime_director,anime_episodes,anime_Status) values (1, "Tokyo Ghoul", "Kentarô Hagiwara", 12, "Completed");
insert into info (animeId, anime_title, anime_director,anime_episodes,anime_Status) values (2, "Spice and Wolf", "Takeo Takahashi", 13, "Completed");
insert into info (animeId, anime_title, anime_director,anime_episodes,anime_Status) values (3, "Evangelion", "Hideaki Anno", 26, "Completed");
insert into info (animeId, anime_title, anime_director,anime_episodes,anime_Status) values (4, "Attack on Titan", "Tetsurō Araki", 25, "Completed");
insert into info (animeId, anime_title, anime_director,anime_episodes,anime_Status) values (5, "86", "Toshimasa Ishii", 11, "Completed");
insert into info (animeId, anime_title, anime_director,anime_episodes,anime_Status) values (6, "Cowboy Bebop", "Shinichirō Watanabe", 26, "Completed");

insert into theme (anime_info_id,anime_theme,anime_genres,anime_studio,original_title) values (1,"Psychological","Action, Drama, Horror, Mystery, Supernatural", "Studio Pierrot", "東京喰種 トーキョーグール");
insert into theme (anime_info_id,anime_theme,anime_genres,anime_studio,original_title) values (2,"Historical","Adventure, Fantasy, Romance", "Imagin","狼と香辛料");
insert into theme (anime_info_id,anime_theme,anime_genres,anime_studio,original_title) values (3,"Psychological","Action, Avant Garde, Drama, Sci-Fi", "Gainax","新世紀エヴァンゲリオン");
insert into theme (anime_info_id,anime_theme,anime_genres,anime_studio,original_title) values (4," Military","Action, Drama, Fantasy, Mystery", "Wit Studio","進撃の巨人");
insert into theme (anime_info_id,anime_theme,anime_genres,anime_studio,original_title) values (5,"Military","Mecha, Military", "A-1 Pictures","エイティシックス-");
insert into theme (anime_info_id,anime_theme,anime_genres,anime_studio,original_title) values (6,"Space","Action, Adventure, Comedy, Drama, Sci-Fi", "Sunrise","カウボーイビバップ");



select * from info;
select * from theme;
select anime_title,anime_director,anime_episodes,anime_status,anime_theme,anime_genres,anime_studio,original_title from Anime.info, Anime.theme where info.animeId = theme.anime_info_id;
