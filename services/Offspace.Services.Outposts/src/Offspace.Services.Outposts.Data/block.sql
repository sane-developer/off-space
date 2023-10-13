create table block
(
    id         INTEGER not null
        constraint block_pk
            primary key autoincrement,
    type       TEXT    not null,
    position   INT     not null,
    outpost_id INTEGER
        constraint outpost_fk
            references outpost,
    constraint is_valid_position
        check (position >= 0 AND position <= 48),
    constraint is_valid_type
        check (type IN ('regular', 'root'))
);

