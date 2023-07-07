import { BadgeItemModel } from 'src/modules/common-shared/models/badge-item.model';

export interface NavigationItemModel {
  id: string;
  title: boolean;
  name: string;
  url?: string;
  icon?: string;
  order: number;
  children: NavigationItemModel[];
  badge?: BadgeItemModel;
  permissions?: string[];
  parentId?: string;
  hiddenTitle: boolean;
}
