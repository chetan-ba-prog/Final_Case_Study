export class Response {
}

export interface Result {
  new(): Result;

  isSuccess: boolean;
  message: string;
  response: any;
  totalRecords: number;
  errors: string[];
  statusCode: number;

}

export const pageLimitOptions = [
  { value: 25 },
  { value: 50 },
  { value: 75 },
];