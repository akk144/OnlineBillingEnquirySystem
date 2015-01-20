select * from customerteamd65
select * from connectionteamd65
select * from calldetailsteamd65
select * from bill_TeamE65
select * from BillItem_TeamE65
select * from tariffplanteamd65

/*-------------bill generation Table 1-----------*/

create table bill_TeamE65
(
Bill_Id bigint identity(1,1) primary key,
CustomerId varchar(20)not null,
ConnectionId int not null,
Amount decimal(7,2) not null,
GenerationDate datetime not null,
_year int not null,
_month varchar(10) not null,
Arrears decimal(7,2) null,
Advanced_Payment decimal(7,2) null,
Discount_Amount decimal(7,2),
Total_Amount decimal(7,2) not null
)


/*-------------bill generation Table 2-----------*/


create table BillItem_TeamE65
(
BillItem_Id int not null foreign key references calldetailsteamd65(callid),
ConnectionNo bigint not null,
DateofCall datetime not null,
Duration bigint not null,
Number_called bigint not null,
TypeofCall varchar(10) not null,
Pulse_Rate money not null,
Pulse int not null,
CostofCall money not null
)
/*-----------------BillItem---------------*/

/*------------------Updating BillItem---------------*/

create trigger updatingbillitem 
on calldetailsteamd65 
for update 
as
begin
declare @duration int
declare @callid int 
declare @typeofcall varchar(20)
declare @pulseRate money
declare @pulse int
declare @totalcost money
set @callid = (Select callid from inserted )
set @duration = (Select duration from inserted )
set @typeofcall = (Select typeofcall from inserted )
	declare @pr money, @p int
	exec getPulse @callid,@typeofcall,@pulseRate=@pr output, @pulse=@p output
set @totalcost=1
	if @p=0
	begin
		set @totalcost=@duration*@pr/100
	end
	if @p=1
	begin
		set @totalcost=@duration*@pr/6000
	end
	update BillItem_TeamE65
	set Duration = @duration,TypeofCall = @typeofcall,Pulse_Rate = @pr,Pulse = @p,CostofCall = @totalcost
	where BillItem_Id = @callid
end

/*------------------Adding BillItem---------------*/

create trigger addingbillitem on calldetailsteamd65 for insert as
begin
	declare @callid int
	declare @typeofcall varchar(20)
	declare @connectionno bigint
	declare @dateofcall datetime
	declare @duration int
	declare @calledno bigint
	declare @pulseRate money
	declare @pulse int
	declare @totalcost money
	set @callid=(select callid from inserted)
	set @typeofcall=(select typeofcall from inserted)
	set @duration = (Select duration from inserted)
	set @calledno = (Select calledno from inserted)
	set @dateofcall = (Select dateofcall from inserted)
	set @typeofcall = (Select typeofcall from inserted)
	set @connectionno = (Select connectionno from inserted)
	declare @pr money, @p int
	exec getPulse @callid,@typeofcall,@pulseRate=@pr output, @pulse=@p output
set @totalcost=1
	if @p=0
	begin
		set @totalcost=@duration*@pr/100
	end
	if @p=1
	begin
		set @totalcost=@duration*@pr/6000
	end
insert into BillItem_TeamE65 values(@callid,@connectionno,@dateofcall,@duration,@calledno,
@typeofcall,@pr,@p,@totalcost)
end

/*-------------------------Calculating PulseRate-----------*/

create proc getPulse
@callId int, @typeOfCall varchar(20),
@pulseRate money out,@pulse int out
as
declare 
	@planId int
begin
	set @planId=(select planid from calldetailsteamd65 inner join connectionteamd65 
	on calldetailsteamd65.connectionNo=connectionteamd65.connectionno where callid=@callId)

	if @typeOfCall = 'LOCAL'
	begin
		set @pulseRate=(select localcallrate from tariffplanteamd65 where planid=@planId)
		set @pulse=(select localpulse from tariffplanteamd65 where planid=@planId)
		end
	else
	if @typeOfCall = 'STD'
	begin
		set @pulseRate=(select stdcallrate from tariffplanteamd65 where planid=@planId)
		set @pulse=(select stdpulse from tariffplanteamd65 where planid=@planId)
	end
	else
	if @typeOfCall = 'ISD'
	begin
		set @pulseRate=(select isdcallrate from tariffplanteamd65 where planid=@planId)
		set @pulse=(select isdpulse from tariffplanteamd65 where planid=@planId)
		 
	end
end

/*------------------Update BillItem----------------*/

create proc update_billitem_teamE_TMS_65
(@BillItem_id bigint
)
as
begin
if not exists(select * from BillItem_TeamE65 where BillItem_Id = @billitem_id)
RaisError('No record Found', 11,2);
else
update BillItem_TeamE65
set BillItem_TeamE65.ConnectionNo = c.ConnectionNo,BillItem_TeamE65.Dateofcall=c.DateOfcall,
BillItem_TeamE65.Duration = c.Duration,BillItem_TeamE65.Number_called = c.CalledNo,BillItem_TeamE65.TypeofCall = c.TypeofCall,BillItem_TeamE65.Pulse_Rate = c.PulseRate,
BillItem_TeamE65.CostofCall = c.CostOfCall
from BillItem_TeamE65 b join calldetailsteamd65 c on b.BillItem_Id = c.CallId
where BillItem_Id = @BillItem_id
end
go

/*----------------------check BillItem----------------*/

create proc check_billitem_teamE_TMS_65 
(@BillItem_id bigint
)
as
begin
if not exists(select * from BillItem_TeamE65 where BillItem_Id = @BillItem_id)
RaisError('No record Found', 11,2);
end
go

/*----------------------check Connection Exists----------------*/

create proc check_connection_teamE_TMS_65 
(@connection_id bigint
)
as
begin
if not exists(select ConnectionNo from connectionteamd65 where ConnectionId = @connection_id and ConnectionStatus in ('active','Active'))
RaisError('Connection does not exists', 11,2);
end
go

/*----------------------View BillItem----------------*/

create proc view_billitem_teamE_TMS_65
(@billitem_id bigint)
as
begin
if not exists(select *
from BillItem_TeamE65 where billitem_id = @billitem_id)
RaisError('No record Found', 11,2);
else
select BillItem_Id,ConnectionNo,DateofCall,Duration,Number_called,TypeofCall,Pulse_Rate,Pulse,CostofCall
from BillItem_TeamE65 where billitem_id = @billitem_id
end

/*------------------ViewAll BillItem----------------*/

create proc viewAll_billitem_teamE_TMS_65
as
begin
if not exists(select *
from BillItem_TeamE65)
RaisError('No record Found', 11,2);
else
select BillItem_Id,ConnectionNo,DateofCall,Duration,Number_called,TypeofCall,Pulse_Rate,Pulse,CostofCall
from BillItem_TeamE65
end

/*------------------ViewAll BillItem by Connection-----------*/

create proc viewAll_billitem_byconnection_teamE_TMS_65
(@connectionNo bigint,
@month varchar(10),
@year varchar(10)
)
as
begin
if not exists(select BillItem_Id,ConnectionNo,DateofCall,Duration,Number_called,TypeofCall,Pulse_Rate,Pulse,CostofCall
from BillItem_TeamE65 where ConnectionNo = @connectionNo and datepart(month,DateofCall) = @month and datepart(year,DateofCall)  = @year)
RaisError('No record Found', 11,2);
else
select BillItem_Id,ConnectionNo,DateofCall,Duration,Number_called,TypeofCall,Pulse_Rate,Pulse,CostofCall
from BillItem_TeamE65 where ConnectionNo = @connectionNo and datepart(month,DateofCall) = @month and datepart(year,DateofCall)  = @year
end

/*------------------Delete BillItem----------------*/


create proc delete_billitem_teamE_TMS_65
(@billitem_id bigint)
as
begin
if not exists(select * from BillItem_TeamE65 where billitem_id = @billitem_id)
RaisError('No record Found', 11,2);
else
delete from BillItem_TeamE65 where billitem_id = @billitem_id
end

/*-----------------Bill---------------*/


/*------------------Create Bill----------------*/

create proc insertbill_TeamE_TMS65
(@Customer_id varchar(20),
@connection_id bigint,
@amount decimal(7,2),
@generatedate datetime,
@year int,
@month varchar(10),
@arrears decimal(7,2),
@advanced_payment decimal(7,2),
@Discount_Amount decimal(7,2),
@total_amount decimal(7,2),
@Bill_Id int out
)
as
begin
if not exists(select * from customerteamd65 where CustomerId = @Customer_id)
RaisError('Customer does not exists', 11,2);
else if not exists(select ConnectionNo from connectionteamd65 where ConnectionId = @connection_id)
RaisError('Connection does not exists', 11,2);
else if exists(select  * from bill_TeamE65 where CustomerId = @Customer_id and ConnectionNo = @connection_id and _month = @month)
RaisError('Bill already exist for this connection for this month', 11,2);
else
insert into bill_TeamE65 (CustomerId,ConnectionNo,Amount,GenerationDate,_year,_month,Arrears,Advanced_Payment,Discount_Amount,Total_Amount) values(@customer_id,@connection_id,@amount,@generatedate,@year,@month,@arrears,@advanced_payment,@Discount_Amount,
@total_amount)
set @Bill_Id = @@identity
end

/*------------------View Bill----------------*/

create proc view_bill_teamE_TMS_65
(@bill_id bigint)
as
begin
if not exists(select * from bill_TeamE65 where Bill_id = @bill_id)
RaisError('No record Found', 11,2);
else
select * from bill_TeamE65 where Bill_id = @bill_id
end


/*--------------------------View Bill By Connection---------------*/


create proc viewAll_bill_by_connection_teamE_TMS_65
(@connectionNo bigint,
@month varchar(10),
@year varchar(10)
)
as
begin
if not exists(select * from bill_TeamE65 where ConnectionNo = @connectionNo and _month = @month and _year = @year)
RaisError('No record Found', 11,2);
else
select * from bill_TeamE65 where ConnectionNo = @connectionNo and _month = @month and _year = @year
end


/*------------------ViewAll Bill----------------*/


create proc viewAll_bill_teamE_TMS_65
as
begin
if not exists(select * from bill_TeamE65)
RaisError('No record Found', 11,2);
else
select * from bill_TeamE65
end

/*---------------------getAmount----------------*/

create proc get_amount_teamE_TMS_65
(@connectionNo bigint,
@month varchar(10),
@year varchar(10)
)
as
begin
if not exists(select sum(CostofCall) from BillItem_TeamE65 where ConnectionNo = @connectionNo and datepart(month,DateofCall) = @month and datepart(year,DateofCall)  = @year)
RaisError('No record Found', 11,2);
else
select sum(CostofCall)  from BillItem_TeamE65 where ConnectionNo = @connectionNo and datepart(month,DateofCall) = @month and datepart(year,DateofCall)  = @year
end

select * from BillItem_TeamE65
select sum(CostOfCall)  from BillItem_TeamE65 where ConnectionNo = 9897033350 and datepart(month,DateofCall) = 3 and datepart(year,DateofCall)  = 2014

/*------------------------Check Ebill-----------------*/


create proc check_ebill_teamE_TMS_65
(@customerid bigint,
@connectionNo bigint
)
as
begin
if not exists(select PaymentMode from connectionteamd65 where ConnectionNo = @connectionNo and ReferenceId = @customerid)
RaisError('No record Found', 11,2);
else
select PaymentMode from connectionteamd65 where ConnectionNo = @connectionNo and ReferenceId = @customerid
end


/*------------------------Get Adjustment-----------------*/


CREATE proc get_asjustment_teamE_TMS_65
(@customerid varchar(20),
@connectionNo bigint
)
as
begin
if not exists(select p.Payment_amount,p.Payment_date,b.Total_Amount from payment_TeamE65 p join bill_TeamE65 b on b.Bill_Id = p.Bill_Id
 where b.ConnectionNo = @connectionNo and b.CustomerId = @customerid)
select count(*) as Advanced_Payment,count(*) as Arrears from payment_TeamE65 where Customer_Id = @customerid and Connection_Id = @connectionNo
else
if((select datepart(day,Payment_date) from payment_TeamE65 where Connection_Id = @connectionNo and Customer_Id = @customerid)  > 15)
select p.Payment_amount-b.Total_Amount as Advanced_Payment,0.05*b.Total_Amount as Arrears from payment_TeamE65 p join bill_TeamE65 b on b.Bill_Id = p.Bill_Id
 where b.ConnectionNo = @connectionNo and b.CustomerId = @customerid
else if((select datepart(day,Payment_date) from payment_TeamE65 where Connection_Id = @connectionNo and Customer_Id = @customerid) > 27)
select p.Payment_amount-b.Total_Amount as Advanced_Payment,0.1*b.Total_Amount as Arrears from payment_TeamE65 p join bill_TeamE65 b on b.Bill_Id = p.Bill_Id
 where b.ConnectionNo = @connectionNo and b.CustomerId = @customerid
 else
 select p.Payment_amount-b.Total_Amount as Advanced_Payment,0*b.Total_Amount as Arrears from payment_TeamE65 p join bill_TeamE65 b on b.Bill_Id = p.Bill_Id
 where b.ConnectionNo = @connectionNo and b.CustomerId = @customerid
end


 /* -------------------------get connection number-----------------------*/

 create proc sp_checkconnectionno1_TeamE65
(
@CustomerId varchar(20))
as
begin
select distinct(ConnectionNo)  from bill_TeamE65
where CustomerId=@CustomerId
end
exec sp_checkconnectionno1_TeamE65 'C1234567'


/*------------------Update Bill----------------*/

create proc update_bill_TeamE_TMS65
(@bill_id bigint,
@Customer_id varchar(20),
@Connection_id bigint,
@amount decimal(7,2),
@generatedate datetime,
@year int,
@month varchar(10),
@arrears decimal(7,2),
@advanced_payment decimal(7,2),
@Discount_Amount decimal(7,2),
@total_amount decimal(7,2)
)
as
begin
if not exists(select * from customerteamd65 where CustomerId = @Customer_id)
RaisError('Customer does not exists', 11,2);
else if not exists(select * from connectionteamd65 where ConnectionNo = @connection_id)
RaisError('Connection does not exists', 11,2);
else
update bill_TeamE65 set CustomerId = @customer_id,ConnectionNo =@connection_id,
Amount = @amount,GenerationDate = @generatedate,_year = @year,_month  = @month,
Arrears = @arrears,Advanced_Payment=@advanced_payment,Discount_Amount= @Discount_Amount,Total_Amount=@total_amount
where Bill_Id = @bill_id
end


/*-----------------------------Check for updation-----------------*/

create proc check_for_update_teamE_TMS_65
as
begin
if not exists(select * from BillItem_TeamE65 b join calldetailsteamd65 c on b.BillItem_Id = c.CallId where c.CostOfCall > b.CostofCall)
RaisError('No record Found', 11,2);
else
select * from BillItem_TeamE65 b join calldetailsteamd65 c on b.BillItem_Id = c.CallId where c.CostOfCall > b.CostofCall
end


create proc check_for_updatebill_teamE_TMS_65
as
begin
if not exists(select * from bill_TeamE65 as b where Amount not in (select sum(CostofCall) from BillItem_TeamE65  where ConnectionNo = b.ConnectionNo and datepart(month,DateofCall) = b._month and datepart(year,DateofCall)  = b._year))
RaisError('No record Found', 11,2);
else
select * from bill_TeamE65 as b where Amount not in (select sum(CostofCall) from BillItem_TeamE65  where ConnectionNo = b.ConnectionNo and datepart(month,DateofCall) = b._month and datepart(year,DateofCall)  = b._year)
end

/*-----------------------------Check to populate list of connection of customers-----------------*/

create proc sp_checkconnectionno1_TeamE65
(
@CustomerId varchar(20))
as
begin
select distinct(ConnectionNo)  from connectionteamd65
where CustomerId=@CustomerId
and ConnectionStatus in ('active','Active')
end

/*=======================================================================================================*/

------------------------------------table creation------------------------------------------

create table payment_TeamE65
(
Payment_Id int identity(1,1) primary key not null,
Customer_Id varchar(20) not null,
Connection_Id bigint,
Bill_Id bigint not null foreign key references bill_TeamE65(Bill_Id),
Payment_amount bigint not null,
Payment_date datetime not null,
Mode_of_payment varchar(15) not null,
Bank_name varchar(50) not null,
Card_number bigint null,
Name_on_card varchar(30) null,
card_type varchar(30) null,
Expiry_date1 datetime null,
Cvv_number int null 
)


-------------------------------------check payment id---------------------------------------

/*check payment*/
create procedure sp_checkPayment_teamE65
(@CustomerId varchar(20),
@ConnectionNo bigint)
as begin
          select Payment_Id from payment_TeamE65 
                 where payment_TeamE65.Customer_Id=@CustomerId and payment_TeamE65.Connection_Id=@ConnectionNo
                  and year(payment_TeamE65.Payment_date)=year(getdate()) and month(payment_TeamE65.Payment_date)=month(getdate())

end


----------------------------------------get customer name--------------------------------------
create procedure getname
(@CustomerId varchar(20))
as
begin
select Name from CustomerTeamD65 where CustomerId=@CustomerId;
end

----------------------------------------add payment/make payment--------------------------------------

create procedure insertpaymentdetails_teamE65
(
@Customer_Id varchar(20),
@Connection_Id bigint,
@Bill_Id bigint,
@Payment_amount int,
@Payment_date varchar(20),
@Mode_of_payment varchar(15),
@Bank_name varchar(50),
@Card_number bigint,
@Name_on_card varchar(30),
@card_type varchar(30),
@Expiry_date1 varchar(20),
@Cvv_number int,
@Payment_Id int 
)
as begin
         insert into payment_TeamE65(Customer_Id,Connection_Id,Bill_Id,Payment_amount,Payment_date,
          Mode_of_payment,Bank_name,Card_number,Name_on_card,card_type,Expiry_date1,Cvv_number)
          values(@Customer_Id,@Connection_Id,@Bill_Id,@Payment_amount,convert(datetime,@Payment_date,103),
          @Mode_of_payment,@Bank_name,@Card_number,@Name_on_card,@card_type,convert(datetime,@Expiry_date1,103),
          @Cvv_number)set @Payment_Id=@@IDENTITY
end

------------------------------------------------------check customer id---------------------------------------------------

create procedure checkcustomerid_teamE65
(@CustomerId varchar(20))
as begin
          if not exists(select CustomerId from  CustomerTeamD65 where CustomerId=@CustomerId)
                    begin
                    RaisError('Customerid is not exists',11,2);
                    end
          else
                    begin
                    select CustomerId from  CustomerTeamD65;
                    end
end



-------------------------------------------check/get connection id----------------------------------------------


create procedure checkconnectionid_teamE65
(@CustomerId varchar(20))
as begin 
           if not exists(select ConnectionNo from CustomerTeamD65 inner join ConnectionTeamD65 
                           on CustomerTeamD65.CustomerId=ConnectionTeamD65.CustomerId 
                            where CustomerTeamD65.CustomerId=@CustomerId and ConnectionTeamD65.ConnectionStatus='Active')
							begin
							 RaisError('Connectionno is not exists',11,2);
							end
			else
                    begin
					     select ConnectionNo from CustomerTeamD65 inner join ConnectionTeamD65 
                           on CustomerTeamD65.CustomerId=ConnectionTeamD65.CustomerId 
                            where CustomerTeamD65.CustomerId=@CustomerId and ConnectionTeamD65.ConnectionStatus='Active';
                     end
end

-------------------------------------------view all payment------------------------------------------
/*Admin-View AllPayment Details*/
create procedure ViewAllPayment_teamE65
as begin
select * from(CustomerTeamD65 inner join payment_TeamE65 
                  on CustomerTeamD65.CustomerId=payment_TeamE65.Customer_Id)
				  inner join bill_TeamE65
                  on payment_TeamE65.Bill_Id= bill_TeamE65.Bill_Id;
end


---------------------------------------view single payment---------------------------------------------------
/*Customer-View Single Payment Details*/

create procedure ViewsinglePayment_teamE65
(@CustomerId varchar(20),
@Connectionid bigint)
as begin
select * from(CustomerTeamD65 inner join payment_TeamE65 
on CustomerTeamD65.CustomerId=payment_TeamE65.Customer_Id)inner join 
 bill_TeamE65 on payment_TeamE65.Bill_Id= bill_TeamE65.Bill_Id
where CustomerTeamD65.CustomerId=@CustomerId and 
payment_TeamE65.Connection_Id=@Connectionid and
 month(getDate())- MONTH(payment_TeamE65.Payment_date)<=3;
end

-------------------------------------------search payment details----------------------------------------------
/*Admin-Search Payment Deatils*/
create procedure ViewSearchPayment_teamE65
(@CustomerId varchar(20))
as begin
select * from(CustomerTeamD65 inner join payment_TeamE65 
on CustomerTeamD65.CustomerId=payment_TeamE65.Customer_Id)inner join bill_TeamE65
on payment_TeamE65.Bill_Id= bill_TeamE65.Bill_Id
where CustomerTeamD65.CustomerId=@CustomerId
end


/*Admin search using connection number*/

create procedure ViewSearchPaymentCon_teamE65
(@Connectionno bigint)
as begin
select * from(CustomerTeamD65 inner join payment_TeamE65 
on CustomerTeamD65.CustomerId=payment_TeamE65.Customer_Id)inner join bill_TeamE65
on payment_TeamE65.Bill_Id= bill_TeamE65.Bill_Id
where payment_TeamE65.Connection_Id=@Connectionno
end

---------------------------------------------search bill details----------------------------------------------
/*select billid and bill amount*/

create procedure billdetails_teamE65
(@CustomerId varchar(20),
@ConnectionNo bigint)
as begin
          select Bill_Id,Total_Amount from bill_TeamE65 
                 where bill_TeamE65.CustomerId=@CustomerId and bill_TeamE65.ConnectionNo=@ConnectionNo
                  and bill_TeamE65._year=year(getdate()) and bill_TeamE65._month=month(getdate())

end

--------------------------------login-----------------------------------------------------

/*Login procedure*/

create procedure logindetails_teamE65
(@CustomerId varchar(20),
@Password varchar(20))

as 
begin
       if not exists (select CustomerId,Password from CustomerTeamD65 where CustomerTeamD65.CustomerId=@CustomerId and password=@password)
                    begin
                     RaisError('CustomerId is invalid',11,2);
                    end
          else
                    begin
					
                    select CustomerId,Password from CustomerTeamD65 where CustomerTeamD65.CustomerId=@CustomerId and password=@password;
                    end
		
end

/*=======================================================================================================*/

/*1.--------creating table for dispute------*/

create table dispute_TeamE65
(
Dispute_Id bigint identity(1,1) primary key,
Bill_Id bigint not null  foreign key references bill_TeamE65(Bill_Id),
Customer_Id varchar(20) not null,
ConnectionNo bigint not null foreign key references connectionteamd65(ConnectionNo),
_Status varchar(15) not null default('Open'),
Problem varchar(100)not null,
Comment varchar(100) null,
Dateofraise datetime not null,
Dateofresolve datetime null,
Cancel_Comment varchar(100) null,
Cancel_Date datetime null
)

/*2.----Check Update in bill table ------*/

create table checkUpdate_teame
(Bill_Id bigint,
Customer_Id varchar(20),
ConnectionId bigint,
Amount decimal(7,2),
Arrears decimal(7,2),
Advanced_Payment decimal(7,2),
Discount_Amount decimal(7,2),
Total_Amount decimal(7,2))


/*--------------------------------------------------------------------------------------*/

/*1.----Trigger for updation on bill table ----*/

create trigger Updatebill_teamE
on bill_teamE65
after update
as
declare @Bill_Id bigint;
declare @Customer_Id varchar(20);
declare @ConnectionId bigint;
declare @Amount decimal(7,2);
declare @Arrears decimal(7,2);
declare @Advanced_Payment decimal(7,2);
declare @Discount_Amount decimal(7,2);
declare @Total_Amount decimal(7,2);

select @Bill_Id=i.Bill_Id from inserted i;
select @Customer_Id=i.CustomerId from inserted i;
select @ConnectionId=i.ConnectionNo from inserted i;
select @Amount=i.Amount from inserted i;
select @Arrears=i.Arrears from inserted i;
select @Advanced_Payment=i.Advanced_Payment from inserted i;
select @Discount_Amount=i.Discount_Amount from inserted i;
select @Total_Amount=i.Total_Amount from inserted i;
insert into checkUpdate_teame
(Bill_Id,Customer_Id,ConnectionId,Amount,Arrears,Advanced_Payment,Discount_Amount,Total_Amount)
values 
(@Bill_Id,@Customer_Id,@ConnectionId,@Amount,@Arrears,@Advanced_Payment,@Discount_Amount,@Total_Amount)


/*---------------------------------------------------------------------------------*/

/*creating Procedures*/
/*1.---------------------Add Dispute---------------------------*/

create proc sp_AddDispute
(
@Bill_Id bigint,
@Customer_Id varchar(20),
@ConnectionNo bigint,
@_Status varchar(15),
@Problem varchar(100),
@Dateofraise datetime,
@Dispute_Id bigint out
)
as
begin
insert into dispute_TeamE65
(
Bill_Id,Customer_Id,ConnectionNo,_Status,Problem,Dateofraise
)
values
(
@Bill_Id,@Customer_Id,@ConnectionNo,@_Status,@Problem,@Dateofraise
)
set @Dispute_Id=@@identity
end;

/*2.----------------------validation for dispute raised in past for a particular bill itemid--------------------------*/


create proc sp_check_TeamE65
(@Bill_Id bigint,
@Customer_Id varchar(20)
)
as
begin
select Bill_Id from dispute_TeamE65
where Bill_Id=@Bill_Id and Customer_Id=@Customer_Id 
end

/*3.-----------creating view procedure by customer-------------*/


create proc sp_ViewDispute
(
@Customer_Id varchar(20),
@ConnectionNo bigint
)
as
begin
if not exists(select 
Dispute_Id,Customer_Id,ConnectionNo,Bill_Id,Dateofraise,Problem,Comment,_Status
from dispute_TeamE65
where Customer_Id=@Customer_Id and ConnectionNo=@ConnectionNo)
raiserror('No record Found',11,2);
else
select 
Dispute_Id,Customer_Id,ConnectionNo,Bill_Id,Dateofraise,Problem,Comment,_Status
from dispute_TeamE65
where Customer_Id=@Customer_Id and ConnectionNo=@ConnectionNo
end


/*5.-------------------view all dispute by a customer-------------------*/


create proc sp_ViewallDispute
(
@Customer_Id varchar(20)
)
as
begin
if not exists(select 
Dispute_Id,Customer_Id,ConnectionNo,Bill_Id,Dateofraise,Problem,Comment,_Status
from dispute_TeamE65
where Customer_Id=@Customer_Id)
raiserror('No record Found',11,2);
else
select 
Dispute_Id,Customer_Id,ConnectionNo,Bill_Id,Dateofraise,Problem,Comment,_Status
from dispute_TeamE65
where Customer_Id=@Customer_Id
end


/*6.------------------creating procedure for deletion----------*/


create proc sp_DeleteDispute
(@Customer_Id varchar(20),@Dispute_Id bigint)
as 
begin
if not exists(select * from dispute_TeamE65 where Customer_Id=@Customer_Id and Dispute_Id=@Dispute_Id)
RaisError('No record Found', 11,2);
else
delete from dispute_TeamE65
where Customer_Id=@Customer_Id and Dispute_Id=@Dispute_Id
end



/*7.----------------------view all dispute details by admin---------------*/ 

create proc sp_viewallAdmin_TeamE65
as
begin
select * from dispute_TeamE65
end


/*8.--------------------Update Dispute by admin-------------------------- */


create proc sp_UpdateDispute
(
@Customer_Id varchar(20),
@Dispute_Id bigint,
 @_Status varchar(15),
 @Comment varchar(100),
 @Dateofresolve datetime
 )
 as 
 begin
 if not exists(select * from dispute_TeamE65 where Customer_Id=@Customer_Id and Dispute_Id=@Dispute_Id)
 raiserror('No record Found', 11,2);
 else
 update dispute_TeamE65
 set _Status=@_Status,Comment=@Comment,Dateofresolve=@Dateofresolve
 where Customer_Id=@Customer_Id and Dispute_Id=@Dispute_Id
 end



/*9.--------------------search by admin------------------------*/


create proc sp_searchbyid_TeamE65
(@Customer_Id varchar(20))
as begin
if not exists(select Customer_Id from dispute_TeamE65 where Customer_Id=@Customer_Id)
raiserror('No record Found', 11,2);
else
select * from dispute_TeamE65
where Customer_Id=@Customer_Id
end



/*10.-------------------Search By Dispute id by admin--------------------*/


create proc sp_SearchByDisputeId_TeamE65
(@Dispute_Id bigint)
as begin 
if not exists(select * from dispute_TeamE65 where Dispute_Id=@Dispute_Id)
raiserror('No record Found', 11,2);
else
select * from dispute_TeamE65
where  Dispute_Id=@Dispute_Id
end

/*11. ------------------Check status of dispute for updation--------------*/


create proc sp_CheckStatus_TeamE65
(@Dispute_Id bigint)
as begin
if not exists(select * from dispute_TeamE65 where Dispute_Id=@Dispute_Id)
raiserror('No record Found', 11,2);
else
select _Status from dispute_TeamE65
where Dispute_Id=@Dispute_Id
end

/*12------------------------Search by both-------------------------------*/

create proc sp_searchbyboth_TeamE
(@Customer_Id varchar(20),
@Dispute_Id bigint)
as begin 
if not exists(select * from dispute_TeamE65 where Customer_Id=@Customer_Id and Dispute_Id=@Dispute_Id)
raiserror('No record Found',11,2);
else
select * from dispute_TeamE65
where Customer_Id=@Customer_Id and Dispute_Id=@Dispute_Id
end



/*13.---------------Check update while updating dispute-------------*/
drop proc checkupdate
create proc chesckupdate_teame65
(@Bill_Id bigint,
@Customer_Id varchar(20))
as begin
select Bill_Id from checkUpdate_teame
where Bill_Id=@Bill_Id and Customer_Id=@Customer_Id
end


/*14.-----------------View all open status in update----------------*/


create proc sp_Viewopenstatus_teamE65
as 
begin 
select * from dispute_TeamE65
where _Status='OPEN' 
end


/*------------------------------get connection number drom dispute table--------------*/

create proc sp_checkconnectionno_TeamE65
(
@Customer_Id varchar(20)
)
as
begin
select distinct ConnectionNo  from dispute_TeamE65
where Customer_Id=@Customer_Id
end



/*------------------------------get connection number drom dispute table--------------*/

create proc sp_checkconnectionno_TeamE65
(
@Customer_Id varchar(20)
)
as
begin
select distinct ConnectionNo  from dispute_TeamE65
where Customer_Id=@Customer_Id
end



/*-------------------------populate connection number---------------------------------*/
create proc sp_checkconnectionno1_TeamE65
(
@CustomerId varchar(20))
as
begin
select distinct(ConnectionNo)  from connectionteamd65
where CustomerId=@CustomerId
and ConnectionStatus in ('active','Active')
end
exec sp_checkconnectionno1_TeamE65 'C1234567'

/*-----------------------------------populate bill id---------------------------*/
create proc sp_checkbillId_TeamE65
(
@CustomerId varchar(20),
@ConnectionNo bigint)
as
begin
select distinct(Bill_Id)  from bill_TeamE65
where CustomerId=@CustomerId
and ConnectionNo=@ConnectionNo
end

exec sp_checkbillId_TeamE65 'C1234567',9858965895


