export interface GetUserResponse {
  id: number;
  name: string;
  registrationDate: Date;
}

export type GetUserListResponse = GetUserResponse[];
