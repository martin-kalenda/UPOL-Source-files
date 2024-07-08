#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																																																																#
# Task:																																																																													#
#																																																																																#
# Let's say we have a directory containing files XYZNNNN.jpg, where XYZ is a prefix and NNNN is a number between 0000 and 9999.																	#
# Inside each file there is a date written in text form in the format MM/DD/YYYY padded by 0 from the left (sort of an equivalent to EXIF data).								#
#																																																																																#
# Write a script that takes said directory as an argument and sorts the files inside into corresponding subdirectories with filepaths in the format YYYY/MM/DD. #
# A subdirectory will only be created if there is a file that will be inside it after the sort.																																	#
#																																																																																#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

if [[ "$#" -ne 1 ]]; then
	echo "path not specified"
	exit 1
fi

path="$1"

for file in "$path"/"XYZ"*.jpg; do
	#convert date string to desired format
	dir=$(awk -F'/' '{ print $3"/"$1"/"$2 }' "$file")

	#check if YYYY/MM/DD directories exist for current file
  if [[ ! -d "$path/$dir" ]]; then
  	#if not, create them
		mkdir -p "$path/$dir"
	fi

	#move file to corresponding directory
	mv "$file" "$path/$dir"
done
