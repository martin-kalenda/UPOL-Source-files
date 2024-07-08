#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																						  #
# Task:																																			  #
#																																							#
# Write two functions that return (print):																		#
# 	1) a number passed as an argument converted from base 2 - 64 in decimal.  #
# 	2) a number passed as an argument converted from decimal to base 2 - 64.  #
#																																						  #
# The first argument is the base (2 is the default).												  #
#																																						  #
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

#check if the given number is possible to convert in given base
check_digit_value() {
    if [ $1 -ge $2 ]; then
      echo "invalid number for conversion, value is too great for base"
      exit 1
    fi
}

#helper function to find the real value (index) of a given character
get_value() {
  local digits="0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@_"
  local index=0

  while [ "$1" != "${digits:index:1}" ]; do
    ((index++))
  done

  echo $index
}

#conversion function from base 2-64 number to a decimal number
num_decode() {
  local number="$1"
  local base="$2"

  local first_digit_index=0
  local power=0
  local result=0

  #check if the number is negative
  if [ "${number:0:1}" = '-' ]; then
    first_digit_index=1
  fi

  #check all digits of a given number from right to left and add them to the result
  #if the given number is negative, don't check value of first character, which is '-'
  for i in $(seq $(("${#number}" - 1)) -1 $first_digit_index); do
    local digit="${number:i:1}"
    local value=$(get_value $digit)
    check_digit_value $value $base
    ((result+=value*base**power))
    ((power++))
  done

  if [ "$first_digit_index" -eq 1 ]; then
    ((result*=-1))
  fi

  echo "$result"
}

case $# in
  1)
    num_decode "$1" 2
    ;;
  2)
    num_decode "$1" "$2"
    ;;
  *)
    echo "wrong number of arguments"
    exit 1
esac
