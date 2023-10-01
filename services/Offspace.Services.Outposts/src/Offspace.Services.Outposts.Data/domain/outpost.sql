create table outpost
(
    outpost_id      integer not null,
    outpost_name    TEXT    not null,
    outpost_country TEXT    not null,
    constraint outpost_pk
        primary key (outpost_id autoincrement),
    constraint outpost_uk
        unique (outpost_name),
    constraint has_approved
        check (lower(outpost_country) IN ('bulgaria', 'germany', 'italy', 'romania', 'switzerland'))
);

