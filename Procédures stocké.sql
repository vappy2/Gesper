/* Exemple du cours*/
 delimiter |
Drop procedure if exist comptage |
create procedure comptage (out compte int)
	begin
	Select count (*) into compte from employe;
	end |
call comptage(@c)|
select @c|

/* procédure utilisateur de la création d'un nouvel employé */
delimiter |
drop procedure if exists creer |
create procedure creer (nom varchar(50), prenom varchar(50), sexe varchar(1), cadre bit, salaire decimal(10,2), service int(11))
	begin
	insert into Employe(emp_nom,emp_prenom,emp_sexe,emp_cadre,emp_salaire,emp_service)
		values(nom, prenom, sexe, cadre, salaire, service);
	end |
call creer("Dupuis","Theo","M",0,2000,2) |
delimiter ;

/*Employé possédant le bac + la licence*/
delimiter |
Drop procedure if exists licence_bac |
Create procedure licence_bac()
begin
select * from employe e inner join posseder p on e.emp_id = p.pos_employe
inner join diplome d on p.pos_diplome = d.dip_id
and d.dip_libelle = "Bac" and emp_id in (select emp_id from employe e inner join posseder p on e.emp_id = p.pos_employe
inner join diplome d on p.pos_diplome = d.dip_id
and d.dip_libelle = "Licence");
end |
call licence_bac()|
delimiter ;
/* La Requête*/
select * from employe e inner join posseder p on e.emp_id = p.pos_employe
inner join diplome d on p.pos_diplome = d.dip_id
and d.dip_libelle = "Bac" and emp_id in (select emp_id from employe e inner join posseder p on e.emp_id = p.pos_employe
inner join diplome d on p.pos_diplome = d.dip_id
and d.dip_libelle = "Licence");

/*liste des salaire compris entre 2 bornes*/
delimiter |
drop procedure if exists salaire|
Create procedure salaire (in int borninf, in int bornsup)
begin
Select * from employe where emp_salaire>borninf & emp_salaire<bornsup;
end |
call salaire(1000,3000)|
delimiter ;

/* Mise à jour du budget d'un service*/
delimiter |
drop procedure if exists budget |
create procedure budget(numservice int,pourcentage decimal)
  begin
  update service
set ser_budget = ser_budget * pourcentage
Where ser_id = numservice;
  end|
call budget(3,0.2)|
delimiter ;
/*La Requête*/
set ser_budget = ser_budget*pourcentagebudget
Where ser_id = numservice;

/*Liste des employés ayant plus de diplome que la moyenne de diplome par employé*/
/*Création de la vue*/
create view NbDiplome(num_emp, nb_dip) as
Select pos_employe, count(*)
from posseder
group by pos_employe;
/*La procédure stockée*/
delimiter |
drop procedure if exists diplome |
create procedure diplome()
  begin
select * from NbDiplome d inner join employe e on d.num_emp = e.emp_id where nb_dip > (select avg(nb_dip) from NbDiplome);
  end|
call diplome()|
delimiter ;
/*La Requête*/
create view NbDiplome(num_emp, nb_dip) as
Select pos_employe, count(*)
from posseder
group by pos_employe;
select avg(nb_dip) from NbDiplome;
select * from NbDiplome d inner join employe e on d.num_emp = e.emp_id where nb_dip > (select avg(nb_dip) from NbDiplome);

/*Liste complète des employé*/
/*La Reqête*/
Select * from employe;

/* Nom et prénom des employés du service 'Atelier A' qui possèdent plus de 2 diplômes*/
Select emp_nom, emp_prenom from employe e inner join service s on e.emp_service = s.ser_id
 inner join posseder p on e.emp_id =p.pos_employe
 where ser_designation = "Atelier A" group by pos_employe having count (pos_diplome)>2;

 /*Augmentation du salaire d'un employé*/
 delimiter |
 drop procedure if exists augmentation|
 create procedure augmentation (in pourcentage int, in nom string)
   begin
   Update employe set emp_salaire = emp_salaire + emp_salaire*pourcentage
   Where emp_nom = nom;
   end
delimiter ;

/*Masse salariale d'un service*/
drop procadure if exists msalariale|
create procedure msalariale(in nomservice string, out msalariale decimal)
  begin
  select sum(emp_salaire) in to msalariale from employe inner join service s on e.emp_service = s.ser_id where ser_designation = nomservice;
  end
delimiter ;

/* créer une vue cadre*/
Drop view if exists cadres;
Create new view adre
as Select * from employe where emp_cadre = 1;

/*Liste des cadres qui gagnent plus que la moyenne des salaires de tous les cadres*/
Select * from cadres where emp_salaire>(Select avg(emp_salaire) from cadres);
