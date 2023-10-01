create table cluster
(
    block_id            integer not null,
    block_neighbor_id   integer not null,
    block_adjacent_side TEXT    not null,
    constraint cluster_pk
        primary key (block_id, block_neighbor_id),
    constraint block_fk
        foreign key (block_id) references block,
    constraint neighbor_fk
        foreign key (block_neighbor_id) references block,
    constraint is_valid_side
        check (lower(block_adjacent_side) IN ('top', 'left', 'right', 'bottom'))
);

