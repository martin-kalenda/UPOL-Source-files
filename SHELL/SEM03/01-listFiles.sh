#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																																												#
# Task:																																																									#
#																																																												#
# List all files and subdirectories in a directory passed as an argument.																								#
# Print information about the filetype ('-' = file, 'd' = directory, 'l' = symbolic link)																#
# and permissions ('r' = read, 'w' = write, 'x' = execute) for the user that ran the script.														#
# 																																																											#
# The format should be: name type permissions (i.e. test d rwx)																													#
# 																																																											#
# If no argument is passed, list files in the current directory, if "-a" argument is given, print hidden files as well. #
# The solution cannot use the ls and dir programs																																				#
#																																																												#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

# get current directory
dir=$(pwd)

# if 2 arguments were passed, save them both
if [ $# -eq 2 ]; then
  opt=$1
  dir=$2
# if only 1 argument was passed, check whether it was "-a"
elif [ $# -eq 1 ]; then
  if [ "$1" = "-a" ]; then
    opt=$1
  else
    dir=$1
  fi
fi

#print hidden files
if [ "$opt" == "-a" ]; then
  for file in "$dir/".*; do
    echo "$file" | awk -F'/' 'BEGIN { ORS="" } { print $NF }'

    #check filetype
    if [ -f "$file" ]; then
    	echo -n " - "
    elif [ -d "$file" ]; then
        echo -n " d "
    elif [ -L "$file" ]; then
        echo -n " l "
    fi

    #check permissions
    if [ -r "$file" ]; then
        echo -n "r"
    else
        echo -n "-"
    fi
    if [ -w "$file" ]; then
        echo -n "w"
    else
        echo -n "-"
    fi
    if [ -x "$file" ]; then
        echo "x"
    else
        echo "-"
    fi
  done
fi

#print non-hidden files
for file in "$dir/"*; do

    echo "$file" | awk -F'/' 'BEGIN { ORS="" } { print $NF }'

    #check filetype
    if [ -f "$file" ]; then
    	echo -n " - "
    elif [ -d "$file" ]; then
        echo -n " d "
    elif [ -L "$file" ]; then
        echo -n " l "
    fi

    #check permissions
    if [ -r "$file" ]; then
        echo -n "r"
    else
        echo -n "-"
    fi
    if [ -w "$file" ]; then
        echo -n "w"
    else
        echo -n "-"
    fi
    if [ -x "$file" ]; then
        echo "x"
    else
        echo "-"
    fi
done
