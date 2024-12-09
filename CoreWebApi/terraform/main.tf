terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "5.76.0"
    }
  }
}

provider "aws" {
  region = "sa-east-1"

  default_tags {
    tags = {
      owner      = "Victor Almeida"
      managed-by = "terraform"
    }
  }
}

resource "aws_s3_bucket" "bucket_test" {
  bucket = "alms.coreapi.test"
}
