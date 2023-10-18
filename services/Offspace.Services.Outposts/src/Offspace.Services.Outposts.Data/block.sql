create table block
(
    id         INTEGER not null
        constraint block_pk
            primary key autoincrement,
    type       TEXT    default NULL,
    position   INT     default NULL,
    outpost_id INTEGER default NULL
        constraint outpost_fk
            references outpost,
    constraint is_valid_position
        check ((position >= 0 AND position <= 48) OR NULL),
    constraint is_valid_type
        check (type IN ('regular', 'root') OR NULL)
);

