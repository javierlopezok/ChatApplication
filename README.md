# ChatApplication

## Setup Instructions

###### Requirements:

- .Net Framework 4.5.2 support.
- RabbitMQ 
- PostgresQL

###### Database SCHEMA:

-postgres
  *tables
    -tbluser
    
###### tbluser create script:

```
-- Table: public.tbluser

-- DROP TABLE public.tbluser;

CREATE TABLE public.tbluser
(
    userid integer NOT NULL DEFAULT nextval('tbluser_userid_seq'::regclass),
    email text COLLATE pg_catalog."default" NOT NULL,
    mobile text COLLATE pg_catalog."default" NOT NULL,
    password text COLLATE pg_catalog."default" NOT NULL,
    dob date NOT NULL,
    CONSTRAINT tbluser_pkey PRIMARY KEY (userid)
)

TABLESPACE pg_default;

ALTER TABLE public.tbluser
    OWNER to postgres;
```   

###### tbluser seed:

```
INSERT INTO public.tbluser(
	userid, email, mobile, password, dob)
	VALUES (1,'test@test.user', '547547444', 'test', '29/01/2019');
```
