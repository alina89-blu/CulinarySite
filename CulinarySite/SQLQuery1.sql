select b.Name, b.CreationYear, a.Name from Books as b join Authors as a on b.AuthorId=a.Id

select r.Name as ReciepeName,
a.Name as [Author Name],
d.Category as DishCategory,
b.Name as BookName,
b.Id as BookId
from Books as b right  join
Recipes as r on r.BookId=b.Id join 
Authors as a  on r.AuthorId=a.Id  join
Dishes as d on r.DishId=d.Id


select a.Name as AuthorName, b.Name as BookName  from Authors as a right join Books as b on a.Id=b.AuthorId

select  b.Name as BookName, a.Id as AuthorId,a.Name as AuthorName from Authors as a left join Books as b on b.AuthorId=a.Id

select r.Name,i.Name,ri.Unit, ri.Quantity
from Recipes as r join RecipeRecipeIngredient  as rri on r.Id=rri.RecipesId join RecipeIngredients as ri on ri.Id=rri.RecipeIngredientsId
join Ingredients as i on ri.IngredientId=i.Id

select b.Name, a.Name from Books as b cross join Authors as a

select b.Name, a.Name from Books as b inner join Authors as a on b.AuthorId=a.Id

select * from Books  where   AuthorId is null

select max(CreationYear) from Books

select * from books as b left join Recipes as r on r.BookId=b.Id

select name, DifficultyLevel+ '/ '+ Content    as bla from recipes

select 'privet/'+ Name from Books

select *from Books

/*update Books
set AuthorId=30 where Books.Id=13;*/

select b.Name as bookName, a.Name as authorName from Books as b,Authors as a
where a.Name= N'Джейми Оливер'
 and b.AuthorId=a.Id


 select * from Books as b where b.Name like  N'[ВДГ]%d'

 

 select * from RecipeIngredients

 select Unit,sum(Quantity),IngredientId from RecipeIngredients group by IngredientId, Unit

 select r.Name,i.Name,ri.Unit, ri.Quantity
 from((RecipeRecipeIngredient  as rri join Recipes as r on rri.RecipesId=r.Id)
 join RecipeIngredients as ri on rri.RecipeIngredientsId=ri.Id 
 join Ingredients as i on ri.IngredientId=i.Id)

 select i.Name, ri.Unit, ri.Quantity from ((RecipeIngredients as ri  join RecipeRecipeIngredient as rri on ri.Id=rri.RecipeIngredientsId)
 join Ingredients as i on ri.IngredientId=i.id)

 select i.Name, ri.Unit, ri.Quantity from RecipeIngredients as ri join Ingredients as i on ri.IngredientId=i.Id

 select * from Authors

 select * from Books

 select Books.Name, Authors.Name from Authors full join Books on Books.AuthorId=Authors.Id

 

 select Books.Name, Authors.Name from Authors full join Books on Authors.Id=Books.AuthorId

 /*select  a.Name, b.Name from Authors as a inner join Books as b on b.AuthorId=a.Id group by a.Name having (select count(b.Name))>1*/

  select count(Quantity), Unit from RecipeIngredients group by  Unit
   select sum(Quantity),IngredientId from RecipeIngredients group by IngredientId

   select count(Name), AuthorId from Books group by AuthorId
   select  a.Name,count( b.Name) as[Number of books] from Authors as a left join Books as b on b.AuthorId=a.Id group by a.Name having count (b.Name)>=1

   select left( Name,2) from Books

 /*  update Books
   set Name=N'Голый повар / The Naked Chef'
   where Id=12
   select Name from Books*/

   select  left( Name,2),Id from Books

   select  Name from Books where Name like N'В%'

   select * from Addresses
   select d.Id, d.Category, r.Name from Dishes as d join Recipes as r on d.Id=r.DishId
      select d.Id, d.Category, r.Name,b.Name from Dishes as d join Recipes as r on d.Id=r.DishId left join Books as b on r.BookId=b.Id
      select d.Id, d.Category, r.Name,b.Name from ((Recipes as r join Dishes as d on r.DishId=d.Id) left join Books as b on r.BookId=b.Id)

      select b.Id as BookId, b.Name,a.Id as AuthorId, a.Name from Authors as a full join Books as b on a.Id=b.AuthorId

      select a.Id,a.Name,b.Name from Authors as a left join Books as b on b.AuthorId=a.Id 
      select a.Id,a.Name,count(b.Name) as [Number of books] from Authors as a left join Books as b on b.AuthorId=a.Id group by a.Id,a.Name having count(b.Name)>1
      select a.Name,count(b.Name) as [Number of books] from Authors as a left join Books as b on b.AuthorId=a.Id group by a.Name having count(b.Id)>0
      select a.Name,count(b.Name) as [Number of books] from Authors as a left join Books as b on b.AuthorId=a.Id group by a.Name 

      select d.Category,count(r.Name) as[nr.of recipes] from Dishes as d left join Recipes as r on d.Id=r.DishId group by d.Category having count(r.Name)>0

      select count(b.Name) as BookCount,b.AuthorId from Books as b group by b.AuthorId
            select count(b.Name) as BookCount from Books as b group by b.AuthorId

            select*from Recipes

           

        update Recipes
        set BookId=9 where Id=5;

        update recipes 
       /* set Name=(select Name from Recipes )+'123' where Id=6*/

        set Name = 'recipe1' where Id=5

        update Recipes
        set Name= (select top(1) Name from Recipes)+'12' where Id=5

         update Recipes
        set Name= (select top(1) Name from Recipes)+'blu' 

          update Recipes
        set Name= (select top(1)  Name from Recipes)+'8' 
        update Recipes
        set Name= 'recipe1' where Id=5
        update Recipes
        set Name= 'recipe2' where Id=6
        
        insert into Recipes (Name,ServingsNumber,DifficultyLevel,Content,AuthorId,BookId,DishId,CookingTime)
        values('recipe3',4,'Лёгкий','123',29,9,1,'2015-08-01 12:30:14')

        update Recipes
        set Name=(select Name from Recipes where Id=6)+'1'
        select * from Recipes

        update Recipes
        set Name='recipe1' where Id=5
         update Recipes
        set Name='recipe2' where Id=6
         update Recipes
        set Name='recipe3' where Id=9

        insert into RecipeRecipeIngredient 
        values(23,5)
          insert into RecipeRecipeIngredient (RecipeIngredientsId,RecipesId)
        values(23,6)
         insert into RecipeRecipeIngredient (RecipeIngredientsId,RecipesId)
        values(24,6)
       
       select * from RecipeRecipeIngredient

       

         insert into RecipeRecipeIngredient (RecipeIngredientsId,RecipesId)
        values(32,5)
        
        select r.Id as [Recipe Id], r.Name,ri.Id as [RecipeIngredient Id],i.Name, ri.Quantity,ri.Unit from RecipeRecipeIngredient as rri  join Recipes as r on rri.RecipesId=r.Id 
        join RecipeIngredients as ri on rri.RecipeIngredientsId=ri.Id 
        join Ingredients as i on ri.IngredientId=i.Id

         select ri.Id as [RecipeIngredient Id],r.Id as [Recipe Id], r.Name,i.Name, ri.Quantity,ri.Unit from RecipeRecipeIngredient as rri   join Recipes as r on rri.RecipesId=r.Id 
        join RecipeIngredients as ri on rri.RecipeIngredientsId=ri.Id 
        join Ingredients as i on ri.IngredientId=i.Id order by ri.Id

        select r.Id as [Recipe Id], r.Name,ri.Id as [RecipeIngredient Id],i.Name, ri.Quantity,ri.Unit from RecipeRecipeIngredient as rri  join Recipes as r on rri.RecipesId=r.Id 
        join RecipeIngredients as ri on rri.RecipeIngredientsId=ri.Id 
        join Ingredients as i on ri.IngredientId=i.Id

        

        select r.Id as [Recipe Id], r.Name,count(ri.Id) as [RecipeIngredient Id] from RecipeRecipeIngredient as rri  join Recipes as r on rri.RecipesId=r.Id 
        join RecipeIngredients as ri on rri.RecipeIngredientsId=ri.Id group by r.Id,r.Name 

        
         select ri.Id as [RecipeIngredient Id],count(r.Id) as [Recipe Id] from RecipeRecipeIngredient as rri   join Recipes as r on rri.RecipesId=r.Id 
        join RecipeIngredients as ri on rri.RecipeIngredientsId=ri.Id 
        join Ingredients as i on ri.IngredientId=i.Id group by ri.Id order by ri.Id


        select * from recipes as r join RecipeRecipeIngredient as rri on r.Id=rri.RecipesId

         select r.Id as [Recipe Id], r.Name,ri.Id as [RecipeIngredient Id], ri.Quantity,ri.Unit from RecipeRecipeIngredient as rri  join Recipes as r on rri.RecipesId=r.Id 
        join RecipeIngredients as ri on rri.RecipeIngredientsId=ri.Id 

        select r.Id,r.Name,rri.RecipeIngredientsId from recipes as r join RecipeRecipeIngredient as rri on r.Id=rri.RecipesId
       
       select  ri.Id, ri.Quantity,rri.RecipesId from RecipeIngredients as ri join RecipeRecipeIngredient as rri on ri.Id=rri.RecipeIngredientsId 
       select top 50 percent Id, Name from Books 
       select top 3 * from Books 
       select top 50 percent * from Books 
       select * from Books where AuthorId is not null
       select * from Books where AuthorId is  null

       select * from Recipes order by DifficultyLevel


      select * from books  where AuthorId in (29,30)
       