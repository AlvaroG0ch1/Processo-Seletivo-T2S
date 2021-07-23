create database T2S
default character set utf8mb4
default collate utf8mb4_general_ci;

create table if not exists Crud_Container(
CtId int not null auto_increment primary key,
CtCliente varchar(30) not null,
CtNumero char(11),
CtTipo enum ('20', '40'),
CtStatus enum ('Cheio', 'Vazio'),
CtCategoria enum ( 'Import', 'Export')
) default charset = utf8mb4;

create table if not exists Crud_Movimentacao(
MovId int not null auto_increment primary key,
MovNumero char(11),
MovTipo enum ('Embarque', 'Descarga', 'Gate In', 'Gate out', 'Posicionamento Pilha', 'Pesagem', 'Scanner') not null,
MovDataInicial date,
MovHoraInicial time,
MovDataFinal date,
MovHoraFinal time
) default charset = utf8mb4;

alter table crud_movimentacao add foreign key (MovId) references crud_container(CtId);
