#!/bin/bash

if [[ "$#" -ne 1 ]]; then
	echo "path not specified"
	exit 1
fi

path="$1"

mkdir -p "$path"

for num in {0001..1000}; do
	#generate random dates (add 1 to avoid generating 0 as output) and write them to files
	printf "%02d/%02d/%04d\n" "$((RANDOM%12+1))" "$((RANDOM%31+1))" "$((RANDOM%9999+1))" > "$path/XYZ$num.jpg"
done
