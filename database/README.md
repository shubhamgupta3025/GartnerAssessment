# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

<!-- These queries are writen in MS SQL Server as I have don't have experience in MYSQL, but I converted these queries to MYSQL using http://www.sqlines.com/ -->

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

    SELECT * from users where id in (3, 2, 4)


2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium

    SELECT first_name, last_name
        ,(SELECT count(*) from listings where status = 2 and user_id = u.id) basic 
        ,(SELECT count(*) from listings where status = 3 and user_id = u.id) premium
    From users u 
    where u.status = 2


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium

    SELECT * from (
        SELECT first_name, last_name
            ,(SELECT count(*) from listings where status = 2 and user_id = u.id) basic 
            ,(SELECT count(*) from listings where status = 3 and user_id = u.id) premium
        From users u 
        where u.status = 2
    ) r where r.premium > 0


4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue

    SELECT max(u.first_name) first_name, max(u.last_name) last_name, c.currency, sum(c.price) revenue from users u 
    left join listings l  on u.id = l.user_id 
    inner join clicks c on l.id = c.listing_id
    where year(c.created) = 2013 and u.status = 2
    group by u.id,c.currency


5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id
    
    INSERT into clicks OUTPUT Inserted.ID values(33, 3, 4, 'USD', GETDATE())
    DELETE from clicks where id = 33


6. Show listings that have not received a click in 2013
- Please return at least: listing_name

    SELECT l.name listing_name from listings l left join clicks c on l.id = c.listing_id and year(c.created) != 2013 where c.id is null


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected
   
    SELECT year(c.created) date, count(listing_id) total_listings_clicked, count(distinct user_id) total_vendors_affected
    from clicks c 
    left join listings l on c.listing_id = l.id
    group by year(c.created)


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names

    SELECT u.first_name,u.last_name,(SELECT STRING_AGG(l.name + ',', ' ') from listings l where l.user_id = u.id) listing_names 
    from users u
    where u.status = 2


<!-- *************************************  MYSQL ******************************************** -->


    SELECT * from users where id in (3, 2, 4)


    SELECT first_name, last_name
        ,(SELECT count(*) from listings where status = 2 and user_id = u.id) basic 
        ,(SELECT count(*) from listings where status = 3 and user_id = u.id) premium
    From users u 
    where u.status = 2


    SELECT * from (
        SELECT first_name, last_name
            ,(SELECT count(*) from listings where status = 2 and user_id = u.id) basic 
            ,(SELECT count(*) from listings where status = 3 and user_id = u.id) premium
        From users u 
        where u.status = 2
    ) r where r.premium > 0


    SELECT max(u.first_name) first_name, max(u.last_name) last_name, c.currency, sum(c.price) revenue from users u 
    left join listings l  on u.id = l.user_id 
    inner join clicks c on l.id = c.listing_id
    where year(c.created) = 2013 and u.status = 2
    group by u.id,c.currency


    INSERT into clicks OUTPUT Inserted.ID values(33, 3, 4, 'USD', NOW(3))
    DELETE from clicks where id = 33


    SELECT l.name listing_name from listings l left join clicks c on l.id = c.listing_id and year(c.created) != 2013 where c.id is null


    SELECT year(c.created) date, count(listing_id) total_listings_clicked, count(distinct user_id) total_vendors_affected
    from clicks c 
    left join listings l on c.listing_id = l.id
    group by year(c.created)


    SELECT u.first_name,u.last_name,(SELECT STRING_AGG(concat(l.name , ','), ' ') from listings l where l.user_id = u.id) listing_names 
    from users u
    where u.status = 2