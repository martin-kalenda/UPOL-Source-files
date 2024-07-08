#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																																											#
# Task:																																																								#
#																																																										  #
# Implement a simplified version of the basename program:																														  #
# 	from a given path (after removing the '/' at the end), return the part from the last '/' to the end of the path.  #
# 	If a path does not contain '/', return the whole given path																												#
#																																																											#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

#simplified version of built-in basename function
basename() {
  #remove possible trailing slash
  local path="${1%/}"

  #if '/' is the only character, return it
  if [[ -z "${path##*/}" ]]; then
    echo "/"
  #if path doesn't contain slashes, return whole name
  elif [[ "$path" != *"/"* ]]; then
    echo "$path"
  #return path up to the last '/'
  else
    echo "${path##*/}"
  fi
}

basename "$1"
