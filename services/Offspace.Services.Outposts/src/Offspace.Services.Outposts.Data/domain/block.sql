create table block
(
    block_id   integer not null,
    outpost_id integer,
    constraint block_pk
        primary key (block_id autoincrement),
    constraint outpost_fk
        foreign key (outpost_id) references outpost
);

