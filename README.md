# Productivity-Tools CLI

## How to use
- from the directory productivity run `dotnet publish`
- navigate to the directory `productivity/productivity/bin/Debug/net7.0`
- feel free to copy the file productivity to where you want it to
- examples of running the command:

```sh
./productivity --todos "walk dogs, feed dogs, cook lunch"
```

The command above will create a new markdown file with todays date with the following contents:


```md

# Wednesday, June 14, 2023

## Todo

- [ ] walk dogs 
- [ ] feed dogs 
- [ ] cook lunch 


## Done

- [ ] 

```