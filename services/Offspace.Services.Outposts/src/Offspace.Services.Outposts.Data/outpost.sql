create table outpost
(
    id   INTEGER not null
        constraint outpost_pk
            primary key autoincrement,
    name TEXT    not null
        constraint outpost_name_uk
            unique
);

