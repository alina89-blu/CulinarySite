import { Address } from '../viewmodels/address.class';
import { Comment } from '../viewmodels/comment.class';
import { Telephone } from '../viewmodels/telephone.class';

export interface IRestaurant {
  id: number;
  name: string;
  telephones: Telephone[];
  comments: Comment[];
  addressId: number;
  address: Address;
}
