USE [Restaurent_BO]
GO
/****** Object:  StoredProcedure [dbo].[master_crud]    Script Date: 12/22/2017 2:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[master_crud]
@country_id bigint=0,
@city_id bigint=0,
@area_id bigint=0,
@country_name nvarchar(100)=null,
@cur_pair nvarchar(100)=null,
@city_name nvarchar(100)=null,
@area_name nvarchar(100)=null,
@status int=0,
@mode int
as 
begin
if(@mode=11)
begin
insert into tbl_country
(
country_name,
status_value,
cur_pair
)
values
(
@country_name,
1,
@cur_pair
)
end

if(@mode=12)
begin
insert into tbl_city
(
country_name,
city_name,
status_value
)
values
(
@country_name,
@city_name,
1
)
end

if(@mode=13)
begin
insert into tbl_area
(
country_name,
city_name,
area_name,
status_value
)
values
(
@country_name,
@city_name,
@area_name,
1
)
end

if(@mode=21)
begin
update tbl_country set 
country_name=@country_name,
status_value=1
where
country_id=@country_id 
end

if(@mode=22)
begin
update tbl_city set 
city_name=@city_name,
status_value=1
where
city_id=@city_id 
end

if(@mode=23)
begin
update tbl_area set 
area_name=@area_name,
status_value=1
where
area_id=@area_id 
end

if(@mode=31)
begin
update tbl_country set
status_value=0
where
country_id=@country_id
end

if(@mode=32)
begin
update tbl_city set
status_value=0
where
city_id=@city_id
end

if(@mode=33)
begin
update tbl_area set
status_value=0
where
area_id=@area_id
end

if(@mode=41)
begin
select * from
tbl_country
end

if(@mode=42)
begin
select * from
tbl_city
end

if(@mode=43)
begin
select * from
tbl_area
end

if(@mode=51)
begin
select 
country_name
from tbl_country
where country_id=@country_id 
end

if(@mode=52)
begin
select 
city_name
from tbl_city
where city_id=@city_id 
end

if(@mode=53)
begin
select 
area_name
from tbl_area
where area_id=@area_id 
end
end