create table parking
(
    id              serial      not null primary key,
    parkingposition int         not null default 0,
    nowparking      boolean     not null default false
);
create table driver (
    id serial not null primary key,
    name varchar(50) not null,
    surname varchar(50) not null,
    park_place int not null references parking,
    parking_pay boolean not null default false

);

select driver.id, name, surname, parkingposition, nowparking, parking_pay  from parking inner join driver on parking.id = driver.park_place;

